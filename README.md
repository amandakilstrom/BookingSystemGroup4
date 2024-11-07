# BookingSystemGroup4

# Begränsningar i programmet
Om man inte skriver in en starttid kommer starttiden automatiskt vara från kl 00:00.


## ShowAllBookings Amanda/Johan
En metod som har en foreach loop som går igenom alla lokaler först och
sen i en ny foreach loop går igenom alla bokningar och skriver ut det åt användaren.

## UpdateBooking Amanda
En metod som ber användaren att söka efter bokning via datum. Det som användaren skriver in
går igenom en if sats för att se om det var ett datum användaren skrev in. Det kommer att loopas tills 
användaren faktiskt skriver in ett datum. 

Efter är det två foreachloopar som går igenom listorna och där finns en if sats som stannar loopen om 
sökningen finns i bokningslistan. Där får användaren ändra i sin bokning. Om sökningen inte hittade
en bokning kommer ett meddelande till användaren om att bokningen inte hittades.

## RemoveBooking Amanda
En metod som ber användaren om ett datum för en bokning som ska raderas. Det är två foreach loopar 
som går igenom listorna och stannar när sökningen matchar en bokning. Där är det en if sats som raderar
bokningen. Om sökningen inte hittades kommer användaren få ett meddelande om det.

## ShowAllRooms Emiliano/Amanda/Johan
Metod som returnerar namn och antal platser för alla salar

## CreateRoom Emma/Emiliano
Metoden skapar ett nytt rum. Användare tilldelar det nya rummet ett namn och antal sittplatser. Bara dessa två egenskaper får
tilldelas, egenskaperna bokningstid och bokningslängd följer per automatik med varje rum. 

## Förhindra att salar har samma namn Emiliano Johan
Kod som finns i metoden CreateRoom som går igenom listan med lokaler för att kontrollera att två rum inte har samma namn.

## Meny Emiliano/Amanda


