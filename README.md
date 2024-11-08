# BookingSystemGroup4

# Begr�nsningar i programmet
Om man inte skriver in en starttid kommer starttiden automatiskt vara fr�n kl 00:00.


## ShowAllBookings Amanda/Johan
En metod som har en foreach loop som g�r igenom alla lokaler f�rst och
sen i en ny foreach loop g�r igenom alla bokningar och skriver ut det �t anv�ndaren.

## UpdateBooking Amanda
En metod som ber anv�ndaren att s�ka efter bokning via datum. Det som anv�ndaren skriver in
g�r igenom en if sats f�r att se om det var ett datum anv�ndaren skrev in. Det kommer att loopas tills 
anv�ndaren faktiskt skriver in ett datum. 

Efter �r det tv� foreachloopar som g�r igenom listorna och d�r finns en if sats som stannar loopen om 
s�kningen finns i bokningslistan. D�r f�r anv�ndaren �ndra i sin bokning. Om s�kningen inte hittade
en bokning kommer ett meddelande till anv�ndaren om att bokningen inte hittades.

## RemoveBooking Amanda
En metod som ber anv�ndaren om ett datum f�r en bokning som ska raderas. Det �r tv� foreach loopar 
som g�r igenom listorna och stannar n�r s�kningen matchar en bokning. D�r �r det en if sats som raderar
bokningen. Om s�kningen inte hittades kommer anv�ndaren f� ett meddelande om det.

## SearchBooking Johan
Metod som ber anv�ndaren att mata in ett �r som ska visa alla bokingar under de �ret. Det anv�ndaren skriver in
g�r f�rst igenom en if sats f�r att se om anv�ndar har skrivit ett giltigt format. Sen �r det tv� foreach loppar den f�rsta 
f�r att g� i igenom alla locals/rum och den andra f�r att g� igeom alla bokningar i varje locals/rum. S� �r det en if sats 
som kollar om det finns n�gon bokning under det �ret och om det �r det s� skriver den ut infomation om bokningen.
Om det inte finns n�gon bokning eller anv�ndaren skriver in fel s� meddelas anv�ndaren.


## ShowAllRooms Emiliano/Amanda/Johan
Metod som returnerar namn och antal platser f�r alla salar

## BookRoom Johan
En metod som g�r en bokning. F�rst s� fr�gas anv�ndaren vilket rum man vill boka, om det rummet finns s� g�r man vidare
till Vems namn bokningen ska vara i, om man skriver in ett namn s� g�r man vidare. Vilken start datum och tid man vill boka
om man skriver in ett giltigt datum och tid s� g�r man vidare. Anv�ndaren fr�gar om hur l�nge man vill boka, om man skriver in
en giltig tid s� g�r man vidare. Nu fr�gas anv�ndaren om man vill g�ra bokningen om ja(y) "s� kollas om bokningen inte �verlappar
med n�gon annan bokning" om bokningen inte �verlappar s� g�rs bokningen och l�gger in den i listan, annars s� kastas bokningen och
anv�ndaren f�r b�rja om.
Om anv�ndaren skriver n�got fel eller inget s� meddelas anv�ndaren och f�r testa igen.

## CreateRoom Emma/Emiliano
Metoden skapar ett nytt rum. Anv�ndare tilldelar det nya rummet ett namn och antal sittplatser. Bara dessa tv� egenskaper f�r
tilldelas, egenskaperna bokningstid och bokningsl�ngd f�ljer per automatik med varje rum. 

## F�rhindra att salar har samma namn Emiliano Johan
Kod som finns i metoden CreateRoom som g�r igenom listan med lokaler f�r att kontrollera att tv� rum inte har samma namn.

## Meny Emiliano/Amanda


