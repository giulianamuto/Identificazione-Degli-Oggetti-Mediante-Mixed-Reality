/*
 Ciao :-) Sono Giuliana è ho iniziato questo progetto, ti consiglio di scrivere qui ogni cosa e
 commentare il codice che modifichi o scrivi per fare in modo che chi lavorerà dopo di te
 non debba decifrare quello che tu hai fatto!! So che è un pò scocciante però per la riucita
 di questo progetto devi farlo ;-) Puoi anche commentare questo script così tutti sanno quello che è stato modoficato
 dall'inizio.
 
 
 Tante informazioni sui plug in usati ecc le trovi sulla mia tesi quindi evito un copia e incolla ma ti dico le
 cose più importanti che devi assolutamente sapere.
 
 Inizio col dirti che in questo plug in di Vive quasi nulla è commentato e per me è stato un duro lavoro
 ma ti assicuro che con un pò di impegno c'è la farai anche tu.

 Ti consiglio di leggere la mia tesi (può dartela la dottoressa Paola Barra o se mi contatti per email te la invio)
 specialmente il capitolo 2 e 3 che parlano del lavoro che ho svolto nei minimi dettagli

 Detto ciò, iniziamo!! 

 *************************************************************************************************************
 Leggi la documentazione eprchè ti spiega tante cose !! 
 Appena aprirai il progetto ci saranno degli errori
 ma la documetanzione dice che se si presentano quegli errori bisogna ignorarli
  *************************************************************************************************************
  Cose che non sono riuscita a modificare:
 - Quando parte le scanner se uno dei joystick non è acceso non funziona
 *************************************************************************************************************
 Quando parte l'applicaizone puoi notare che c'è quando scannerizza la scena vedi lo spatial scan
 PER TOGLIERNO  prefab ViveSR in RididReconstrucctor e dpve ci sono quei due materiali li togli e inseirisci 
 un materiale che si chiama "New Matirial" (orignale vero?)
 
 CONSIGLIO: 
 ti consiglio di toglierlo solo nella fase finale per provarlo e poi rimetterli perchè
 è utile per capire cosa stai scannerizzando e se sta scannerizando
 *************************************************************************************************************
 Gli script con i metodi modificati sono:

 ViveSR_DualCameraRing ------> Metodo SetMode 
 Sample9S_SemanticSegmentation ------> Quasi Tutto
 ViveSR_SceneUnderstanding --------> GetElementsBoundingBoxMeshes,GetElementsIcons
 Quest'ultimo è molto importante è ti consiglio di leggere sulla mia tesi la parte in cui parlo del riconoscimento degli oggetti
 li spiego come funzionano le mesh cube in unity e quindi potrai capire GetElementsBoundingBoxMeshes al meglio

 Per entrare nel dettaglio cerca questi scirpt perchè li ho commentati
 
 *************************************************************************************************************
 Gli script che ho scritto sono:
 -InstanziatePrefabs
 *************************************************************************************************************
 Con questo ho finito, buon lavoro !!!
 

 Giuliana
 */