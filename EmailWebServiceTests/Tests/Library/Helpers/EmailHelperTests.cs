﻿using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.Models;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace EmailWebServiceTests.Tests.Library.Helpers
{
    public class EmailHelperTests
    {
        public EmailHelperTests()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [Fact]
        public async Task SendEmailTests()
        {
            try
            {
                var model = new EmailSchemaModel()
                {
                    From = "mariusz.a.szczerba@gmail.com",
                    DisplayName = "DisplayName",
                    Subject = "Subject",
                    Body = @"<p style=""color:blue;"">Niebieskie niebo</p><p>#TestParametr#</p>",
                    ReplyTo = "mariusz.a.szczerba@gmail.com",
                    ReplyToDisplayName = "ReplyToDisplayName"
                };

                var footer = new EmailFooterModel()
                {
                    Id = 1,
                    TextHtml = @"<p >Pozdrawiam,</p><p style=""color:red;"">Mariusz XYZ</p><img style=""width:100px; height:100px; float:right; "" src=""cid:footer"">",
                    Logo = new EmailLogoModel()
                    {
                        Id = 1,
                        Name = "test",
                        FileBase64String = "/9j/4AAQSkZJRgABAQEASABIAAD/2wBDAAYEBQYFBAYGBQYHBwYIChAKCgkJChQODwwQFxQYGBcUFhYaHSUfGhsjHBYWICwgIyYnKSopGR8tMC0oMCUoKSj/2wBDAQcHBwoIChMKChMoGhYaKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCj/wgARCAKAAoADASIAAhEBAxEB/8QAHAABAQADAQEBAQAAAAAAAAAAAAcFBggBBAMC/8QAFAEBAAAAAAAAAAAAAAAAAAAAAP/aAAwDAQACEAMQAAABqgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAMLI6lzybrucXpZXwAADXzKzqdYs2fG4kbHtkwHS+T5hthuQAAAAAAAAAAAAAAAAAAAAAAAAAAAAANb556G55FLmlLK+AADH877vNg92E179eg9hOVvOk48ab+/4DonYYHfAAAAAAAAAAAAAAAAAAAAAAAAAAAAADW+eehueRS5pSyvgAee/Ec5Y/3w/fpCJ38Afj+w5rxNGnJ/XTHMvQRtAAAAAAAAAAAAAAAAAAAAAAAAAAAAANb556G55FLmlLK+AB8n1jlbzM4Y2XoXljoI2UAxhKJ/8AZ8Y6FgHTZ9IAAAAAAAAAAAAAAAAAAAAAAAAAAAAMBzr1JzMfHsOvDoD9+eB0VsHNfSgBMJJ1Jz+a393xeFk2XnYW+U4YDKG2WrHZEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAaDvw5b/LpbUyKK2J10pOaMAPh+4QbT+qdUIApuMNF9o+2EsuGW/sAAAAAAAAAAAAAAAAAAAAAAAAAAAYLOyE2tCBd0IF3QgXdCRdkJ8LuhAu6EC7oQLuhAu6Eel2QkXZCBd0IF3QgdG52Q14AAAAAAAAAAAAAAAAAAAAAAAASGvSEmYBtRr++VHJmifVuIn2q2scu/P0xHTSXvgA9+y2E13aijTvl3sRvQ+oMYc0Nq1UAplekNeAAAAAAAAAAAAAAAAAAAAAAAAEhr0hJmDYOgde2oGkm7flzhijqlzTVChS7yTnvgP0/iiG+bSB8clLM5vyZfWsbOfNz70Xqpz+CmV6Q14AAAAAAAAAAAAAAAAAAAAAAAASGvSEmeZw27lzBiecbBGRtOr9EknXgQdeBB9P6o5ZPz6E586iP3MURnUPfAD6uiebKwVIHN2G3fSCmV6Q14AAAAAAAAAAAAAAAAAAAAAAAASGvSEme86NnjowE6jXSfOR+XRPOuxHRDn3NFoB+XLnQ3O5/XUfLXRJsOHzHhyv5sutngFWl3Q5ngQ7Rs9gSmV6Q14AAAAAAAAAAAAAAAAAAAAAAAASGvSEmfvg6I2Ln6+n6aJvY5j+LqXGEHuOc/oGDJ9M/2/A9pky/c6jYDPmLjd4HLmV6OGlbqDXc9AjV/AplekNeAAAAAAAAAAAAAAAAAAAAAAAAEhr0hJmD3d9HHUH1c0UUqTVvqM+0zTijwnHfiAAZS588fqdSotupujAfKbT8s3nRsukeACmV6Q14AAAAAAAAAAAAAAAAAAAAAAAASGvayc9rMIyswjPtlEa8swjSyiMrMIyswjKzCMrMIz7ZRGfbKI15ZhGVmEZWYYWvazswAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB//8QAKxAAAQIGAgEEAgIDAQAAAAAABAMFAAECBhAWIDRQERIUNRMVIUAwMbAy/9oACAEBAAEFAv8AgfPC9YrbsrjGyuMWy6EuC/8AgIXSGTOummU131wWj9gZCL04JQFdVcoCNQNT87cf0uLI7PN3c0m1A81c5biOuoMqxPNDhT5y4/pcWR2eRxNAYpxShpOfx1+mUlKklGVwk4h+buP6XFkdnleRvvJw0NirksA0BhSgxvFLk+MtbdPFtGfEc/N3H9LiyOzyOW+QZCSdSqreJQCJlVOlZN0EmEdH+oAW+QF5q4/pcWR2eJs/aFi2E5KPXG9aJSNxbNXuZPNXH9LiyOzxKp94uLdW/C8cbzWlW5Ytyj2Mvmrj+lxZHa5O4/xXKJfxNjcaXATLgWmCKUtWSRCdE1FB0pID+afqfez4ZT5txiT+3V0/u26E3gBSvN5A+6jAhKoiwF0IVyk8t/oZcoaUnFwXcFcWiD+c3zatElEykahiODT9plVOlVN6ba24nm3hqnEgCphC+cuNmmbJSipOvLT9pwLGSLQd2NcGfFraiHCtsb0W9DzxYIxklbWDqidppxqVEC2xSgTyOYgi5rWorKNYPhG1CJwFbgQ86ZSpp8w4ugzfXsjdGyN0bI3RsjdGyN0bI3RsjdGyN0bI3RsjdGyN0bI3RsjdGyN0bI3RsjdGyN0bI3RsjdGyN0bI3RsjdGyN0bI3RsjdGyN0bI3RsjdDc6DOFfkr37P9yyOz5K9+zwQRUXUDtYiuSVsA0xrjdC1rCVQXbBaUKpVo18wGA0uB7VGpiVuN0K2wDVBlrEJyXRUQU4WR2fJXv2csrQq41hBIBJcTQ0DE3piVB4jDqErM7GgDLiaEgak9NCrdXmyOz5K9+zhnb6nExBKhBHP5KOFyPnpwppnXUwtdLcNzXSoXReG+puMxZHZ8le/ZxboMgm7D490gQW4FFzgU4kWpmuGgmdxvnpxs8H8xWCiEhkXC5l1aqnM6qYr+ehNod0XKWLiBka3Ysjs+Svfsw0IfKcsOhUggVK6lFIGYziUNbcY1xxjW3GNbcY1txif8Ti3R/jtGLjcZnG5QVrQVajJHA4d0PiuUWR2fJXv2YtCn3PGL1U9AMMH03Gv/ANwjT7EYdVfwNvGyFZ+zF30+14iyOz5K9+zFn1ejvi9U/UDDB9NwUq9ic/5nCU/cnDun+Vr42QnPN4VervFkdnyV79mGRf4zrh1E+aApRUnXCDwcgj++coaHB0POw/r/AB2jDAv8hpw+gTAOzRTOutlC+ABh7X+S6xZHZ8le/ZwxG/ObsP7HI6ZIywtcN7aSfW0tqTaPi8jPerizTfarg8JE5Bwt8wWdSVdMxGwwqbIxpgZfTfgt2LI7Pkr37OGBy/XF0VU10Yroprp/XBe6UpUyw7OFDeIspUsrhJSpJRmcaHETnXVTRQ/uX7EvFkdnyV79nLC91AQOukQlxdHIduTcTlTyOABioJDU6oONHEhdIdJ+e6j+FkdnyV79ngGYuGoHdUvRJ+blIm8N8oXuNvTkdc66sKV1q18qKp0VAXMSjJC5AFJSeG+cKvzcnBl1S9DDFzFOFkdnyV79n+5ZHZ8k7NCLlXqgkaoJGqCRqgkaoJGqCRqgkaoJGqCRqgkaoJGqCRqgkaoJGqCRqgkaoJGqCRqgkaoJGqCRqgkaoJGqCRqgkaoJGqCRqgkNLQi21/8AA5//xAAUEQEAAAAAAAAAAAAAAAAAAACg/9oACAEDAQE/AUgf/8QAFBEBAAAAAAAAAAAAAAAAAAAAoP/aAAgBAgEBPwFIH//EADwQAAECAgQLBwIGAgMBAAAAAAECAwAEEBEhchIgIjEyM0FQUZKhEyNSYXGRwTSBFDBCYrHRQHMkQ7CT/9oACAEBAAY/Av8AwPn3mrFpFkabfJGm3yQ8mZUkhKaxUKvyS4+tKEDaYwZJrC/e5/UfUFI4IFUfVv8A/wBDGTNLN7KiqcZCh4m8/tGHLuBfEbRv6au/NMzcH5GEvKcOgjjHaTC6+A2DGDjCyhY2iOzdqRMjZ4vTfs1d+aZm4Mdx93RSPeFvPGtR6eWJXgqq9MRK2yUrTaCIDmZxNix578mrvzTM3BjolEnJbyletNSMlsaS+EDs2gpfjXaaO/ZSo+LMfeO0bJXLn9W1PrSgE927kK+N+TV35pmbgx3nj+tRNCG0CtSjUIQw3+nOeJ44im3BWhQqIh1g/pNh4ilh7xoB33NXfmmZuDGfPBtX8Uy9eytXTGYXtUiqmW+4677mrvzTM3BjPI8SCKZZRzE4PvjIbH/Wi370yo8q+u+5q780zNwY8w1sCrPSiyASe+RY4PnEW+8bBmHE8Icec01ms0JQi1SjUIbaTmQkJ33Nj9ldIdqwkEYKh5RX2+D5KSY+qR7GEoRMpKlGoC3ERONjRyV+mw0h1hWCsQBOILS/Em1MV/i24PYYT6vKwRhvqs/SkZk0/iVju2c17fikK0VCow4y5pINWLKf7U/ziKQ4K0KFREVZ2VaCvyEssi05zwHGEMNDJTt479/ES/1AFo8YgocSUqGcHElP9qf5xVNPpwkGCtALsv4hs9cbuk4Le1xWaOzZFp0lHOrf/wDyWUr89sZC3kfeuLJtXJH1auSGnRNE4CgqrAx68Dsl+JuyO4mEG8Kozs80d6+0m7bGE4FPq/fm9oASKgNg3yhMwVAqFYqFcaa+SNNfJGmvkjTXyRpr5I018kaa+SNNfJGmvkjTXyRpr5I018kaa+SNNfJGmvkjTXyRpr5I018kaa+SNNfJGmvkjTXyRpr5I018kaa+SNNfJGmvkjTXyQtMuVEpFZrFW85a6f8ANmbo3nLXTi4DKFLWdgiuacS0OAyjGWXV+qo1Sucx3TjqOsEsKQ8PYwUOoUhQ2EfkBRR2LfFz+o795xw+WTGqVzmMgut+iorlXEujgckxgPIUhY2HFmbo3nLXTiV6DA0l/Ajs5dASNp2nGwJhsLHUQXWa3ZfjtT64qWmE4S1bIC3KnZjxbB6Y3ZzCAobDtEV6bB0V/BxJm6N5y100hsWNi1auAhLTScFCRUBiaSffEXKSZtzOL+BiBKRWTYIygDMK01fH5C2nU4SFCoiC2bWzahXEUzN0bzlrppRWO9cy109kyAuY6J9YrffWryrs9qK2H1o8q7IDU5U26cyv0q/qFSkkq3MtwfwMVUysZLVib1KnX1BKBtgpkwGUeI2qiszb/PFrvap4LtioZDwzoPxSuod63lopmbo3nLXTRLtHMVW+lLr+1Is9YUtZwlKNZNCHmkJKFisZUatHOI1aOcRq0c4jVo5xGrRzilgbVjDP3pKUnuGzUnz88RLjSsFaTWDDb4znSHA0zDQzBVnpRM3RvOWumgHwoJpZR4nPimUuYyvWhCRsSBRMuDOGzVjTTOwVKFJPiQDRM3RvOWumiri2RSyvwuVdKZS5iqVwFdKDxFE0gZy2caac2WJpq4NgUTN0bzlrpolnDmwqj97KXWNqhk+sKQsVKSaiKEtNPlKE2AYIj6k8ohtoTCsHOs4IsFMwraU4A+9MsraE4J+1Kk1d0vKbPliBKASo2ACEMnT0l+tMy4M2FUPtZRM3RvOWumltdeWnJX60l+XqTMbeC4wJhtTavOiphGTtWcwjAbylnSXxpblEGxGWv12UrlFmxeUj120lp9NY2HaIJaT27fFGf2ipSFA+YjumF1eIioR2rpDkxx2J9KXF15aslHrTM3RvOWummtWoXYsfMBSCCk2gimpaQocCIr/CMV3BFQFQpLqrV5kJ4mFOOGtajWTSlxs1KSawYDgscFi08D+QVLICRaSYrTqEWIHzTM3RvOWunE7F6tcsfdEBxlYWg7RjVvGtZ0UDOYLrx9E7EjFDrBqO0bCIyDgu7Wznxi48sIQNpjsWa0Sw914kzdG85a6cXDlnCg9DFU4zb4m/6j6jBvJIj6tr3jJWt0/tTBTKoDI8RtMFbiipRzk44UglKhmIjBmUh9PHMqMtS2j+5P8AUfVtx9RhXUkxVJs2+Jz+ow5lwrPQYszdG85a6f8ANmbo3mhTq3E4AqyY1z/SNc/0jXP9I1z/AEjXP9I1z/SNc/0jXP8ASNc/0jXP9I1z/SNc/wBI1z/SNc/0jXP9I1z/AEjXP9I1z/SNc/0jXP8ASNc/0jXP9I1z/SNc/wBI1z/SNc/0jXP9I1z/AEhamluKwxVlf+B1/8QAKxAAAQICCAcBAQEBAAAAAAAAAQARIVEQIDFBYdHw8VBxgZGhscEw4UCw/9oACAEBAAE/If8AgfHpAYkQ94WwFsBAsGYYn/G1IoVHXYgdARIvLh6xROXLui9E3wJvsiYvxhdy3wmKgYHMHHvDelOuT/DCIwxL4FFW3MAyArWN2zKGoXIWBPJx3w3pTrk697AmvK4BXNQi4bgwqAjBpnVCZwvYFQbQXum5HjnhvSnXJ1yQimZnZ2HunFl8QwCZTBEtA7l0oKxhwz0RT0TM4RJZqTtNy6Nrv7PHPDelOuTrEsHNgRTx2Xk8KGkTjmShWBgsOcVQdk0VeER5xzIiD2oBJAiBCnwR5tHjfhvSnXJ1jg7SPKm4D3gJqwWi0sWP9pIQbh2j434b0p1ydY4i3uYpAcsSfQR7Na4XRzE/pqXktJ95HjfhvSkoWh65GFiTzojwaCICRBEQQhvGhifg1O7Ay6BHJcvKoFswCmSrITHQNxsoCfsj8pdbYGYnBig6LkBHha4+ID7zaImy6oVxDYxoPDqKSG76LxIzCvOkA99HlFsdR0NhurO+Tko1wQghYD7SQnsQrO1vbjkT8vlEIdDHnjjV0OSoCaYLvBR6YJBM8SOI/BwtGuL4lBFEbx3k8daCIKz/AKIuj2DYipoclUCW63gzEirbUmojg+2VgaAmEh5TOCiZxLcY5cfaJOwEGDqIo2ThrA8hXI8wzWxc0TZ2aOxdra58Zl5jmLEcLLcD+jovWuL8kTDbgJ/EGBHSz66CEGYAYDjJAYkLeS3kt5LeS3kt5LeS3kt5LeS3kt5LeS3kt5LeS3kt5LeS3kt5LeS3kt5LeS3kt5LeSADFxMWrT/26tPierTqh1lQblARqu/4+0BDnNj0ESixRbr4kCmlncPWYeVbUibH8AAAmETytIKOTID6gxEuJQDiU3PYRAKrv+PpH1tQbGrq0+J6tOpFclszb7D6QnzYCzJrSOwfQbli8Ok6+qpup0A98kN20uHZfaxnyYCzBUVyWzNnoPupq0+J6tOl6LVheUPU3C6pEaNJlRiDMYt0/oahqBYALSUBEAvIwYDz+A4T8r09Fq4vFOrT4nq06YRQQTnYOg+0nyYw5B0jgiUIOEHRCgWbFxxcxYg3Q4dp9Ln4pZotqgc63LyyHsU2zFy9DFXcEgBPgUWlgQQviw4utqs75yvJXimMUEk5WjqPlOrT4nq06GVOORwRPgUlMAYCbygPKPnKFWkmh0DQIiFZjhhhgHAbRCgTM3WcXpqST3w7iv1uqEOMyuKY1AGBc2illTHkcUR4NGrT4nq06BkNmH2kgmx49Czp1GNbzCESh2GEdBQQlZ9YtCsQRbc8XB9CkYDdh8o1afE9WnQB9dXg/KSC7HHUsqdRjVESsMhOGaBYughbAkdqDiMRHMB60dy3OJPykDa+vJ+0atPierToGQNHsInukBpg8I3DEIjM4VaCKAyTuQOy1z8UdqtIbbd060jcm6ogpC6v1XB8oMRFB/FG4YOllQu1WBySgMx8QT25dKRkDx7CB6o1afE9WnSAm4TWC/rb1pJCzgMOZI4o1kQNvI30CBsTQPWU4RMInlhSN3O6BB290i9eMEHb1S82bC1mEcjcisY2uzrA5hQUHh8/qyiIZODNDGkANgmsV/S3pTq0+J6tOkkRMHXS6M0Farg4IpNjLNBNMoQyECwAM1LWpNGumiyDU8TSbyOGuITEOiy43fgFargwARIiIuvn1ZU6tPierTqEg6Fl5MYYaNgf49YparSYDFYXIXQCq3/YE6IodhYjYOUxWtD/HRIuhZeTOGGhTq0+J6tOq/jLQC/MF6KA0Xj/WaDWCl8BAHPQcirDB/rIdo6dw8o5r3LcmuXiDkMQUBBmEfmsKFsEGPlyDOOqWQawUvgIIjTcP8ZpvGWAluQLqurT4nq0/9urT4mV+kANi/MLcsi3LItyyLcsi3LItyyLcsi3LItyyLcsi3LItyyLcsi3LItyyLcsi3LItyyLcsi3LItyyLcsi3LItyyLcsi3LItyyLcsiK/QEGwbkP+B1/9oADAMBAAIAAwAAABDzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzwzzzziwxzDzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzyzyjyzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzhwTyzxjzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzjzzxRTzxSTzzzzzzzzzzzzzzzzzzzzzzzzzzzzxCwzzxzyxzhTzzzzzzzzzzzzzzzzzzzzzzzzzzzzzxjjTzxjzSTzzzzzzzzzzzzzzzzzzzzzzzzzzywwwwwwwwwwwwwwxzzzzzzzzzzzzzzzzzzzzzzzzzzzizwxjzySzxzTzzzzzzzzzzzzzzzzzzzzzzzzzzzwTxRCzzhzTTRjzzzzzzzzzzzzzzzzzzzzzzzzzzyzzThwxzzjzyzxzzzzzzzzzzzzzzzzzzzzzzzzzzyjzijzzwyzzyjxTzzzzzzzzzzzzzzzzzzzzzzzzzyzixQTzyjTzzzRzzzzzzzzzzzzzzzzzzzzzzzzzzzyxjDhzzzjDCRzzzzzzzzzzzzzzzzzzzzzzzzzzzjzzzzzzzzzzzzzzTzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz/xAAUEQEAAAAAAAAAAAAAAAAAAACg/9oACAEDAQE/EEgf/8QAFBEBAAAAAAAAAAAAAAAAAAAAoP/aAAgBAgEBPxBIH//EACsQAQABAgQGAgICAwEAAAAAAAERITEAEEFRIGFxgZHwUKGxwTBAsNHhYP/aAAgBAQABPxD/AAHwR7tkUmjei5kAGERYxQal6fw0iYQgugaryJcKqjJUV3RKdU6YkjVhJ0R9nEvm6cICDNQHxcWzGRFzUjscIdaIKl0ep+HSf/A5/U7/AOBZCNIQWq6Or2JcNk1T8Vkc6rqrxPGS1MaiWR1GRwCKxWNebU1uLkkx8/n9Tv43QikGE05pYMSZ3TWLY6A/a1V4OQmbHmMIiiIlxzI6FiBNExF5I07LDuHcrD8/n9Tv42XwiNB0PVnvzewrK0Loauh5TEL7URm4pHQDAAAEBaMP8hAOsEHZMYGROKgWhpXQQLSBicp9BAWAr6YE7fPmf1O/iJkAJV0MNCnx0Sh0CDtk1bctQB5cVZSHBXzF8EFjgClhVEITCQp9Lilc5E85yYlRIjCOJO8asQ8z89n9Tv4qC5nqJmDAXid2+0PbiOkLU3cPj653la5sE+ez+p38RoqQDVU/eGl8g9vhtTfo4lAlrGzI/b3zQhHh1fSfPZwJVVg462sPX/XmT5CkIRNTB2sxYSNAcieTJpwRkAgWHeQvglaDiidgWJaDkEByDJYI56oA8uIo6F6hS+vmyLVIJzizS9OPCEZlSCCbwkkzhmhyvXJCPC5YBpFEl0CupQ4INJDqSanRKfwZ0dtFQS4WTZxR7IR5iDxR1Yi4GyD4ScQ9jE2Tk58LEZkmpBpuOqlYK0Iymx3aUNR2LyPN84LkBt0D9OLNwXSDQckhOSfwkgKaTISEcN88h3K2k731/gcSmSU1zoH2wFUwhQhJc15pfFAoHzpYeVUAWrYNibkE0MSUQRfsjU/hpHGKqpoEuGjiXMEdPit0eExxWrAQN0/Cd4K4O0yCpdVoGgoS6qvzqTgYWFDLYiHZxNXbE37PvCmStlfrltBp+jo1ScTF+KMNd9VSbeFfWBd8PWryfOAMQGyDFwZ3B3kH3isKKsA8qD0WB54CAFgCgfMyx9DCDDMf3ffffffffffffffffffffffffffffZY+hgFgifk/f7f7vv8Af8n7/bw3h+HBq0sc2mCW5LEOTCDs4H2swF6BR5xDh+5P9uAl039FQfvBUjSPMeimD9Cho+zxhLBgikCTE3Al3Ad8IEAqTHpV94iafM/pMOzSID3G/OCG5JMORKru4XB4HBo1ucynD7/f8n7/AG8EljqKlqP2WudBpUXJROrX6NAOJVGrOQu51XTvghYqw0eQuctNyieCPzgljVNgarQxQSZT12a3VV5W4q1FwVTqx+nUTEFroKloP2WuNQz9/v8Ak/f7c3XAhltsaaAdWw4MTIegPyt1aqq1c1gloY/c1fnAiSVN8xZQI5DZW+mhYrUzAX0cqYAN1wFI4idw/ki6uwcbobWsP4S4lRBK4dMCSX2zpoPZsmfv9/yfv9ubGKAFRE98CN3dnO26cm2YVUVAlKsESxjJAumgHjKWFJk9Qyu5hUzFJ0Azc5sO5QxzJujqxro6LFanBJ34IkFf7uqaZi3eb1dAurQK4tegEu9Z6ILzwK6APwIYlbF0I8T5w9mqzlNaDxCallyYxAAqontiRubM/f7/AJP3+3IxlkLNP8mDKN8t1HQ9JE8pwyqy5WlXvlKbBmZRUWS2PWv3j3r949a/ePWv3j1r94W5xXUymTkZIWi8Q9s11jC0VE3VmNoWl4DnYbqH5NEaIw4HOdVtOlNTkmTgxkkLFP8ABl7/AH/J+/25AdKXyX/bzb2Ooyk8jxn9Z+XC2x6DfAQC6wYDaDLYAPxksRIGjQvKcT4yFbB6PTMDoW+af6eXv9/yfv8AbkbSvOiP4FmUi9EFZ5PnP6z8uFC4TOwC4VG6VxAC4zh25dtxDlJIKd0A8nEWMjn7j6g+WbNK9aL+AZe/3/J+/wBuUIwDmANR5BLtmkWgSZL0kB5LgInFwtCPMTKLWUrUmJWt9chtCO4YUSm1aDmM6yfw3dH0Fe2YIju8a/mge+QEAIkI64X2EAqTXrbLlDqcBWHygmADVXE7iRiRjgOoAB1M0owRmRMQ5JLvl7/f8n7/AG5DDSjgrwk6UMJdEf8ADMYWhRotLZoWNB3BK1iSHNYHMUybnpE9fGryJeWGVlx41qaCWJUluquVOABOUTmNe3OFdMbb8wI9++d4wHRo30fpsiYCw1Zo+GexzwkM2Eg7Jhx9iqA3pHiXD/rAbu4Gq6TBigEs5FeUnQppDon/AKYWWtXL3+/5P3+3OT5hUoTRNWT1EXjAgHjEiREuJnfT8BuzTAQWWRL/AEiMEEuBgNgM29BVNdPsutDmgsfCF0S53SRRMkcImeEaxXDlKupcf4FAPGBEqrYDEnzGhQmqaMDoAvOfv9/yfv8AbwV3agZRfdTV60rJgYMZmDmOomo1NeISqC0W0puXVOrTBf5vtxQPy3XhvRSEyqnqPkYSExHjLC8xf3HcOIwYzEHINVdAq6Yru1UwC2yGp0rWDge/3/J+/wBvDLihTAaPTuOmLEnSA85aeXTB6G9cHej7xRocxeAnCwQsZL1iwpc0nOqU+jqxOFZd+6tXjK5JudZEqOCGZUgHMD3CXfEsduUHsPxiJyc1eEnD6S9cPej7xYk6ADnLXw6YlxRpgdDp2HXh9/v+T9/t/u+/3/Jq9KwgU1k/u06dOnTp06dOnTp06dOnTp06dOnTp06dOmr0rGBTSD/Adf/Z",
                        Type = "jpg"
                    }
                };
                model.EmailFooter = footer;

                var usserList = new List<IEmailRecipientModel>()
                {
                    new EmailRecipientModel()
                    {
                        Name = "Recipient",
                        EmailAdress = "mani3k1989@gmail.com"
                    }

                };

                List<EmailSchemaVariablesModel> var =
                [
                    new EmailSchemaVariablesModel()
                    {
                        Id = 1,
                        Name = "TestParametr",
                        Value = "wartość parametru"
                    }
                ];

                model.EmailSchemaVariables = var;


                var cfg = new EmailAccountConfigurationModel()
                {
                    SMTP = "smtp.gmail.com",
                    Port = 587,
                    Login = "mani3k1989@gmail.com",
                    Password = "igco tpcj dcrl ytnr"
                };

                using var stream = File.OpenRead(@"C:\Users\mani3\OneDrive\Pulpit\cv.pdf");
                var file = new FormFile(stream, 0, stream.Length, "cv.pdf", Path.GetFileName(stream.Name))
                {
                    Headers = new HeaderDictionary()
                };

                var attachments = new FormFileCollection()
                    {
                        file
                    };

                await EmailHelper.SendEmail(model, usserList, cfg, attachments);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public void CreateBodyTests()
        {
            try
            {
                var old = @"<p style=""color:blue;"">Niebieskie niebo</p><p>#TestParametr#</p>";
                var model = new EmailSchemaModel()
                {
                    From = "mariusz.a.szczerba@gmail.com",
                    DisplayName = "DisplayName",
                    Subject = "Subject",
                    Body = old,
                    ReplyTo = "mariusz.a.szczerba@gmail.com",
                    ReplyToDisplayName = "ReplyToDisplayName"
                };


                List<EmailSchemaVariablesModel> var =
                [
                    new EmailSchemaVariablesModel()
                    {
                        Id = 1,
                        Name = "TestParametr",
                        Value = "wartość parametru"
                    }
                ];

                model.EmailSchemaVariables = var;

                EmailHelper.CreateBody(model);


                if (string.Compare(old, model.Body) == 0)
                    Assert.Fail($"Treść maila nie została przerobiona {old} {model.Body}");

            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
    }
}
