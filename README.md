# simpleFPS

Unity version: 2021.3.5f1

Prosty fps z możliwością używania broni

Użyto:
 - ScritableObjects
 - Object pooling
 - Eventy
 - Player input

# Sterowanie
Gra obsługuje sterowanie zarówno na klawiaturze jak i gamepadzie

Klawiatura i mysz:
 - W - ruch do przodu
 - S - ruch do tyłu
 - A - ruch w lewo
 - D - ruch w prawo
 - Spacja - skok
 - Lewy shift - sprint
 - R - przeładowanie/akcja specjalna
 - Prawy przycisk myszy - atak

Gamepad na przykładnie Xbox:
 - Lewy analog - ruch postaci
 - Prawy analog - ruch kamery/rozglądanie się
 - A - skok
 - X - przeładowanie/akcja specjalna
 - LT - sprint
 - RT - atak
 - lewa strzałka - poprzedni przedmiot
 - prawa strzałka - następny przedmiot


# Bronie
Bronie maja swoje odpowiednie cechy takie jak obrażenia, czas przeładowania, rozrzut, ilość amunicji czy wielkość magazynku. Bronie również mają określony rodzaj materiału na który mają wpływ. Implementacja ustawiania broni jest łatwa do rozszerzenia o na przykład bronie do walki w zwarciu.


# Przedmioty
Każdy obiekt na mapie reaguje na pociski broni. Obiekty dzielą sie na otrzymujące obrażenia oraz te które pełnią jedynie rolę tła bez możliwości ich zniszczenia. Każdy z przedmiotów o ustawionym materiale odpowiednio zasygnalizuje miejsce otrzymania ciosu/strzału poprzez system particli. Jeżeli obiekt nie posiada na sobie informacji o materiale jest traktowany jakby był zrobiony z metalu jedynie dla wizualizacji.
![image](https://github.com/Sabekk/simpleFPS/assets/5255050/97dca146-9a5f-4218-80b4-5620b2b7ee8c)

![image](https://github.com/Sabekk/simpleFPS/assets/5255050/451bfeed-6f59-44fc-b1aa-9ded16bcda45)


Przedmioty reagujące na obrażenia na koniec swojego życia wywołują dodane do obiektu akcje.
Obecnie zaimplementowane akcje:
 - efekt wizualny
 - zamiana obiektu
 - wpływ na podpięty obiekt

Efekty mogą się ze sobą łączyć
![image](https://github.com/Sabekk/simpleFPS/assets/5255050/73377536-016b-4e9c-b2a2-7011bb9e5a8b)


# UI

Użytkownik jest informowany o obecnym statusie broni oraz aktualnie wyposażonego przedmiotu poprzez zawsze widoczny HUD
![image](https://github.com/Sabekk/simpleFPS/assets/5255050/ca720106-d962-49f0-a8d0-5716992a87c2)

Po trafieniu w obiekt reagujący na obrażenia gracz jest informowany o zadanych obrażeniach oraz o aktualnym statusie przedmiotu
![image](https://github.com/Sabekk/simpleFPS/assets/5255050/74e3b0cf-303e-4ba3-823d-e86a61932e51)

Jeżeli broń trzymana przez gracza nie ma wpływu na atakowany przedmiot gracz również jest o tym informowany komuniaktem
![image](https://github.com/Sabekk/simpleFPS/assets/5255050/587cf4e8-0417-4eb7-9670-879b7f8220e7)

