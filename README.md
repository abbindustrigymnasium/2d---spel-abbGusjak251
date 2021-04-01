# Mitt spel i Unity

Jag har planerat att göra ett spel som liknar en "top-down shooter" i Unity, med 3d-modeller och 3d-grafik men med en kamera som är låst. 

# Gameplay

Huvudkaraktären bär ett vapen som aldrig får slut på ammunition och som ger ifrån sig höga smatterljud när skott avfyras. 
Man befinner sig på ett stort block omringat av murar i mitten av skärmen, och kan röra sig åt alla håll (inga hopp) men inte till andra sidan av spelplanen. 
Där spawnas fiender, i vågor, som rör sig mot spelaren. För varje våg ökar antalet fiender som spawnas. 
Spelarens mål är såklart att skjuta ner så många fiender som möjligt och ta sig förbi så många vågor som möjligt. Jag vill hålla det på den nivån, då jag vill att spelet ska vara så simpelt som möjligt. 
Vem som helst ska förstå spelmekanismerna och kunna ha kul utan att känna att de behöver lära sig avancerade tekniker. 
I teorin behöver spelet aldrig ta slut, men det kommer i princip vara omöjligt att ta sig förbi våg 20 då skärmen kommer vara täckt av blod, sprickor och annat som kommer begränsa spelarens synfält. 
Tanken är att spelet ska bli så gott som omöjligt att spela efter ett tag.

# Meny/inställningar

Man befinner sig alltid i samma scen, även när man ska välja inställningar och faktiskt starta spelet. Menyn består av två knappar: Start och Settings. 
De inställningar som spelaren har kontroll över är ljudvolymen och mängden effekter. 

# Grafik/miljöer och belysning

Jag kommer att kombinera mina egna 3d-modeller med annat jag hittar på internet på sidor som t.ex. turbosquid och open game assets. Bakgrunden kommer förmodligen att vara helt svart, om jag inte ändrar mig när allt är på plats. 
Belysningen kommer att bestå av en enkel lampa placerad ovanför spelplanen + global ljussättning med en skybox. Eventuellt lägger jag till effekter som rök och dimma om jag har tid över när resten av spelet är klart. 

# Kontroller

Man rör sig med WASD/piltangenterna och skjuter genom att hålla ner vänsterklick på musen. För att avsluta spelet räcker det med att trycka escape och för att starta om spelet håller man in R.

