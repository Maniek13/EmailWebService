W razie chęci wykorzystania, proszę o kontakt

Rozsyłanie emaili na listę użytkowników połączonych z serwiserm. Treść maila moze zawierać automatycznie wypełniane pola, jak i podpis, stopkę, oraz logo. Wartości zmiennych można podać w form-data, przy braku podania wartości pobierane są z bazy danych.


Konfiguracja:
- należy ustawić service, z którym są powiązane inne dane
- edycja schematu po zmiania zmiennych wiąże się z usunięciem/bądź aktualizacją poprzednich
- edycja listy po zmiania osób wiąże się z usunięciem/bądź aktualizacją poprzednich
- edytując alementy zawierające inne, można je edytować razem. Wiązę się to z możliwością usunięcia ludzi z listy, podczas załączenia pustej listy.
- można mieć kilka list odbiorców, ale serwis narazie wysyła tylko wiadomosći do wielu z pierwszej ustawionej listy
- mogą występować pomniejsze błędy, jak i podczas błednego zapytanie wyświetlac się surowe wiadomości

![Schemat bazy](https://github.com/Maniek13/EmailWebService/assets/47826375/40589c47-82fe-4561-8ae5-07d01102a1ef)


Zamiana parametrów na inne niż w bazie. 
- należy przesłać tekst json jako form file: "[{"id":0,"emailSchemaId":0,"name":"TestParametr","value":"string"},{"id":0,"emailSchemaId":0,"name":"TestParametr2","value":"string2"}]"

  
Domena:
- wysyłanie wiadomości email do wszystkich z listy ustawionej w konfiguracji
- schemat wiadomości:
    Jeżeli w schemacie występują zmiennne prosze je ustawić pomiędzy znakiem: #. 
    Przykład:
  ![image](https://github.com/user-attachments/assets/d5bb2dc5-6fd3-4db5-a76a-5849863e63f6)

- stopka:
    Jeżeli chce się zamieścić podpis w html z logo proszę je umieścić w ciele jako img z ustawionym cid na footer. Jak ponieżej:
![image](https://github.com/user-attachments/assets/d66c38bc-21f1-4500-8558-d437ee0e25a2)

    
Należy zmienić connection string do połączenia z bazą danych



