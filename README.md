# jumper-assignment-Joeprogrammer69

gekozen opdracht 
-  de agent wordt geconfronteerd met een rij van continu bewegende obstakels.
---- HOW IT WORKS ----
Het programma werkt met een spawner die prefabs spawnt. De agent moet de prefab detecteren via een sensor en er over springen.
De agent zal eerst detecteren waar de target is, op voorwaarde dat hij op de vloer is, springt hij omhoog.
Er zijn verschillende condities, zoals
- de agent mag niet te hoog gaan
- De agent mag niet de map af vallen
- De agent mag niet colliden met de Target
Als 1 van deze factoren worden getriggerd, krijgt de agent strafpunten.

Bij elke succesvolle jump , krijgt de agent een reward, zelfs met gewoon te jumpen (hoeft niet over de target) krijgt hij al een kleine reward. Dit zorgt ervoor dat hij consistenter blijft jumpen.

De spawner werkt met een empty prefab die op de target duplicate na een tijdsinterval. Elke target die van de map valt, wordt verwijdert. 

![image](https://user-images.githubusercontent.com/114059274/233732442-ca0bf5e9-b193-48a4-80c2-93ae64c97d0e.png)




De training daalt in ene diepe dal, maar stijgt dan wel rap en blijft op een baseline hangen. Bij episode length, stijgt het ahrd maar daalt het ook geleidelijk aan.
