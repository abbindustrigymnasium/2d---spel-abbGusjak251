# Mitt spel i Unity

Jag har valt att bygga ett spel, som än så länge är namnlöst, i unity 3d. Det kan liknas vid en top down shooter.
Huvudkaraktären bär ett vapen som aldrig får slut på ammunition och som ger ifrån sig höga smatterljud när skott avfyras. 
Man befinner sig på ett stort block omringat av murar i mitten av skärmen, och kan röra sig åt alla håll (inga hopp) men inte till andra sidan av spelplanen. 
Där spawnas fiender, i vågor, som rör sig mot spelaren. För varje våg ökar antalet fiender som spawnas. 
Spelarens mål är såklart att skjuta ner så många fiender som möjligt och ta sig förbi så många vågor som möjligt. Jag vill hålla det på den nivån, då jag vill att spelet ska vara så simpelt som möjligt. 
Vem som helst ska förstå spelmekanismerna och kunna ha kul utan att känna att de behöver lära sig avancerade tekniker. 
I teorin behöver spelet aldrig ta slut, men det är i princip omöjligt att ta sig förbi våg 30-40 då kaoset blir för svårt att hantera. 
Tanken är att spelet ska bli så gott som omöjligt att spela efter ett tag.

# Projektbeskrivning

I detta projekt använde vi oss av en spelmotor vid namn Unity, som tillåter dig att utveckla spel i både 2d och 3d. Unity är väldigt användarvänligt och lätt att förstå sig på, vilket gjorde att man snabbt kunde få en fungerade prototyp av sitt spel klar. För att planera och strukturera projektet använde vi oss av en planner i microsoft teams, där vi lade in ett antal punkter som vi ville få gjorda. Vi uppdaterade sedan plannern och lade till nya punkter under projektets gång. På så sätt hade man bra koll på vad som behövde göras och hur nära man var på att gå i mål. Dessutom var det lätt att hålla koll på buggar och oväntade problem som dök upp, som man annars kanske hade glömt bort. 

Vi fick runt 8-10 timmar på oss att slutföra projektet. Då vi färdigställt våra spel fick vi para ihop oss två och två och testa varandras spel. Vi fick ge och ta emot feedback, känna av hur väl spelet fungerade och sedan göra förbättringar innan vår redovisning inför resten av klassen. Under redovisningen fick vi presentera vårt spel och berätta om hur vi skapat det, vilka problem vi stött på etc.

# Resultat/problem

Resultatet hade definitivt kunnat bli bättre. Mina spelmekanismer fungerar dock ganska bra och det går att ha kul samtidigt som man spelar spelet, vilket jag är glad för. Spelets svagaste sida skulle jag vilja säga är grafiken. Den kunde jag ha förbättrat genom att till exempel göra egna 3d-modeller och animera dem, men å andra sidan var det inte fokus för detta projekt. Det fick bli kuber och kapslar istället. Responsiviteten på min UI kunde även den ha varit bättre. Det märktes när jag skulle redovisa, då information om spelaren och spelet ej ville visas i hörnen.

Jag stötte inte på några allt för stora problem, som tur var. En del andra i klassen fick sina versioner av unity avinstallerade, och jag är glad att det inte hände mig. Däremot stötte jag på en del vanliga buggar och fel i mitt spelbygge och min kod. Till en början kunde t.ex. fiender spawna i varandra och på så sätt få saker att flyga. Det problemet löste jag genom att låta fiender stöta bort varandra vid kollision. Den lösningen blev inte heller helt perfekt, men den fungerade åtminstone temporärt. Det är något som jag skulle kunna förbättra i framtiden.

Ett annat problem var hur blodfläckar hamnade utanför planen. Det har jag faktiskt inte löst ännu, men jag är rätt så säker på att lösningen inte behöver vara särskilt komplicerad. Anledningen till att det problemet fortfarande är olöst är att jag inte upptäckte det förrän samma dag som redovisningen skulle äga rum. Då var jag istället tvungen att prioritera annat, såsom att fixa min UI som inte var helt responsiv (ytterligare ett litet problem).

# Avslut

Trots att mitt spel har en ganska så stor förbättringspotential är jag nöjd över vad jag har åstadkommit i det här projektet. Jag har försökt göra några spel tidigare, men jag har aldrig kommit till den punkten då jag faktiskt har slutfört dem. Det lyckades jag någorlunda med den här gången, vilket motiverar och inspirerar mig till att göra fler spel och arbeta vidare med de projekt som jag redan har påbörjat. 

Att planering och struktur är viktigt har jag blivit påmind om under projektets gång. Om man inte har en plan blir det lätt så att man sätter igång med lite vad som helst, troligtvis saker som man inte borde prioritera. När man har planeringen framför sig blir det tydligt vad som behöver göras för att spelet ska utvecklas och ta sig från en prototyp till en fullbordad applikation som kan betraktas som ett spel. Det kan vara motiverande att veta ungefär hur man ska ta sig i mål. Självklart kommer oväntade saker att ske under resans gång, men det är ändå viktigt att kunna förstå hur långt man har kommit med hjälp av plannern.

