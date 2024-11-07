# BookingSystemGroup4

# Begr�nsningar i programmet
Om man inte skriver in en starttid kommer starttiden automatiskt vara fr�n kl 00:00.


## ShowAllBookings Amanda/Johan
En metod som har en foreach loop som g�r igenom alla lokaler f�rst och
sen i en ny foreach loop g�r igenom alla bokningar och skriver ut det �t anv�ndaren.

## UpdateBooking Amanda
En metod som ber anv�ndaren att s�ka efter en bokning via datum och lokalens namn. Det som anv�ndaren 
skriver in g�r igenom en if sats f�r att se om det var ett datum anv�ndaren skrev in. Det kommer att 
loopas tills anv�ndaren faktiskt skriver in ett datum. 

Efter �r det tv� foreachloopar som g�r igenom listorna och d�r finns en if sats som stannar loopen om 
s�kningen finns i bokningslistan. D�r f�r anv�ndaren �ndra i sin bokning. Om s�kningen inte hittade
en bokning kommer ett meddelande till anv�ndaren om att bokningen inte hittades.

## RemoveBooking Amanda
En metod som ber anv�ndaren om ett datum och lokalens namn f�r en bokning som ska raderas. 
Det �r det en foreach loop som g�r igenom alla lokaler och d�refter �r det en for loop som g�r
igenom listan med alla bokningar. D�refter �r det en if sats som raderar bokningen om en matcning 
med datum och lokal hittades. Om s�kningen inte hittades kommer anv�ndaren f� ett meddelande om det.