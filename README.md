
# Auswirkung des Immersionsgrads auf die empathische Verlegenheit gegenüber Akteuren in virtuellen Umgebungen.

## Projekt

Dieses VR-Projekt wurde für ein Experiment zur Untersuchung der Forschungsfrage: **"Beeinflusst der Immersionsgrad von virtuellen Umgebungen das Ausmaß an empathischer Verlegenheit gegenüber virtuellen Agenten?"** erstellt. 

Es besteht aus 8 Szenen, welche sich aus einer Kombination folgender Faktoren zusammensetzen:  
    - 2 Immersionsgrade: immersiv / weniger immersiv  
    - 2 Peinlichkeitsgrade: peinlich / nicht peinlich  
    - 2 Aktivitäten: laufen / tanzen  

Konkret sehen die Szenen wie folgt aus:

| Szene                            | normal                     | peinlich                   |
| -------------------------------- | -------------------------- | -------------------------- |
| A: In einer Menschenmenge laufen | normal laufen              | stolpern und hinfallen     |
| B: Tanzen                        | geschickt, leerer Raum     | ungeschickt, Menschenmenge |


## Verwendung

Um das Projekt zur **Entwicklung** zu verwenden, sei es zu Testzwecken oder auch zur Erweiterung, wird neben der Codebase lediglich ein Lizenz für Unity benötigt.  
Dabei sollte die Editor Version **6000.0.25f1** verwendet werden um maximale Kompatibilität zu gewährleisten. 

Um das Projekt in einer **virutellen Umgebung** zu testen, wird eine VR-Brille wie die [Meta Quest 3](https://www.meta.com/de/quest/quest-3/)benötigt. Das Projekt wurde speziell auf diese Brille abgestimmt und kann unter Umständen nicht ordnungsgemäß auf einem anderen Modell laufen. Durch einfache Modifikation der Steuerung lässt es sich jedoch auch auf andere VR-Brillen übertragen.

Das Projekt kann einerseits von einem Computer aus gestartet werden, indem man es im Unity Editor öffnet und die VR-Brille mit dem Compouter verbindet (z.B. über die Meta Quest Link App / Steam VR).
Andererseits könnte man eine .apk direkt auf die VR-Brille bauen und installieren, wobei dabei dazu ein entsprechendes Interface zum wechseln der Szenen implementiert werden müsste, oder alle 8 Szenen als einzelne .apks installiert werden müssten.

## Experiment
 
Das Experiment basiert auf dem vorliegenden Code. Dabei sind alle 8 Szenen als eigenständig zu betrachten.  
Die Teilnehmer*innen durchlaufen in zufälliger Reihenfolge (welche zuvor extern generiert wird) jedes einezelne Szenario und bewerten ihr Erlebnis anhand eines Fragebogens.

## Assets

### Umgebungen
Alle verwendeten Umgebungsobjekte sind kostenfrei aus dem Unity Store erworben worden und unter folgenden Links abrufbar:

[Szene 1 und 2](https://assetstore.unity.com/packages/3d/environments/fast-food-restaurant-kit-239419)  
[Szene 3 und 4](https://assetstore.unity.com/packages/3d/environments/apartment-kit-124055)  
[Szene 5 und 6](https://assetstore.unity.com/packages/3d/environments/low-poly-medieval-market-262473)  
[Szene 7 und 8](https://assetstore.unity.com/packages/3d/props/interior/bedroom-interior-low-poly-assets-295074).  

### Charakter und Animationen

Alle verwendeten Charaktere und zugehörige Animationen stammen von [Adobes Mixamo](https://www.mixamo.com).

## Credits

**Authors:**  
Jasmin Döhler  
Marcel Lilie  
Simon Trost  

**Evaluierung von Benutzerschnittstellen | WS 2024/2025**  
**Hochschule Coburg**