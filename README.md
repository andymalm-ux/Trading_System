Programmet använder sig av listor (List) för att spara information om användaren och föremålen. En lista för användaren där information som namn, email, lösenord sparas, samt en lista för föremålen.
Med hjälp av klassen User så ser jag till att informationen för användaren hänger ihop. I den klassen finns även en metod som hanterar inloggningen. Den ser till att om inloggningsuppgifterna stämmer. I det fallet returneras en bool variabel som är true.

I klassen Item ser jag till att informationen som läggs in sparas ihop samt att användarens id sparas ihop med föremålet och dess beskrivning. På detta vis så är föremålen kopplade till användaren.

Informationen för användaren skrivs till en fil, Users.csv. Informationen för föremålet skrivs till filen Items.csv.
Detta för att kunna spara användare och föremål om man startar om programmet.

När programmet startar så skapas 2 st listor, en för User och en för Item. Efter det så läses filerna Users.csv och Items.csv in. Den datan sparas sedan i respektive lista, User och Item. Tidigare skapade användare och föremål finns nu tillgängliga.

Programmet körs sedan i en while-loop. För meny-systemet så används switch-case. Programmet börjar med att kontrollera om man är inloggade. I nuvarande version så är man alltid utloggad när programmet startar. Man hamnar då i första switch-caset. Där väljer man om man vill skapa ny användare, logga in eller avsluta programmet. För att skapa en ny användare så behöver man ange namn, email och lösenord. Datan sparas i listan User, samt skrivs till filen Users.csv.
När man loggar in så efterfrågas användarnamn (email) och lösenord. Inputen kontrolleras mot den datan som finns sparad. Om email och lösenord stämmer så hamnar man i main meny.
Här är en ny while-loop samt ett nytt switch-case. Man kan välja att lägga till föremål, se alla föremål, byta föremål samt logga ut.
Vill man lägga till ett föremål så måste man ange typ och beskrivning. Denna datan ihop med användarnamnet sparas sedan i listan för Item, samt skrivs till filen Items.csv.

Väljer man att visa alla föremål så sker detta via en foreach-loop, som går igenom listan Item och skriver ut i terminalen. 

Vill man byta föremål så visas först alla föremålen med samma foreach-loop som ovan. Sedan skrivar man in vad man vill byta mot vad. Med hjälp av en if-sats i en ny foreach-loop så jämförs inputen med datan som finns sparat. Om inputen stämmer med ett föremål så ändras användaren för det föremålet. Sedan skrivs den nya datan över till en temporär fil, Trades.csv. Innehållet i Trades.csv ersätter sedan innehållet i Items.csv.



Jag fastnade länge med att jag försökte använda mig av en Dictionary istället för en List för att spara datan för items. Jag tänkte att Dictionary skulle funka perfekt just för att då kunde jag använda användarens email som nyckel. Jag fick det inte till att funka vilket gjorde att jag använde mig av en lista istället och la till användaren i den klassen.
Inser att jag skulle bett om hjälp men man är envis och vill försöka lösa problem själv.
Jag började med att använda en interface för metoden TryLogin, men insåg att det inte fanns någon anledning att använda mig av en interface för det. Flyttade metoden till klassen User istället.


