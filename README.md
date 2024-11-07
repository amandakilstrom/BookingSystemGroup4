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