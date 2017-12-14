﻿# TAAlphaTeamProjectOneOOP-Battleships

## -=BATLESHIPS=-

### ImpEx Invest International software team

#### Anton Simeonov, Orlin Draganov, Stefan Zhekov : : OOP Team project #1 : : -=BATTLESHIPS=-

### -=BATTLESHIPS TEAM GUIDELINES=-

### Упътване

### Съдържание
[\-1. Предговор](#preface) 

[0. Какво имаме да направим за момента](#todos) 

[1. Правила](#rules) 

[2. Как протича играта от гледна точка на дизайна](#gameFlow) 

[3. Йерархия на обектите](#objHierarchy) 

[9. Полезни линкове](#usefulLinks) 

<a name="preface" />

### \-1. Предговор

Задачата ни е да направим проста игра, в която демонстрираме ООП, да се сблъскаме с различни проблеми и трудности и да ги преодолеем. 

<a name="todos" />

### 0. Какво имаме да направим за момента

[ ][Йерархия на обектите](#objHierarchy)

[ ]Ако има нужда да коментираме [правилата](#rules)

[ ]Да коментираме [как протича играта от гледна точка на дизайна](#gameFlow)

[ ]Skype среща с Дамян в събота 16 декември 10:00.

<a name="rules" />

### 1. Правила

Играта има двама играчи. Всеки играч има две матрици с размери 10 реда (от 1 до 10) на 10 колони (от A до J) и 5 кораба, с дължина както следва:

Самолетоносач - 5к.

Няк`ъв друг кораб - 4к.

Крайцер - 3к.

Подводница - 3к.

Унищожител - 2к.


В първата част от играта всеки играч си разпределя корабите по едната матрица, като ги крие от другия. 
Във втората част се цикли следното:
Тоя, който е на ред си избира някое поле от матрицата на другия и "стреля" там. Другият казва дали е уцелен кораб или вода, отбелязва си на матрицата с корабите, а тоя, дето е на ред за референция си отбелязва на празната матрица дали е кораб или вода.
Играта свършва като единия унищожи всички кораби на другия.

<a name="gameFlow" /> 

### 2. Как протича играта от гледна точка на дизайна

Според Орлин:
Играта има една единствена инстанция. Една фабрика създава двама играчи, за тях по две char[10,10] \- една твоя и една за реферция на другия \- и по пет кораба. 

Единия играч е човек, другия е компютър, който може да вплете някой [алгоритъм](#algorithm). 

Корабите имат int големина, enum посока {Left, Right, Up, Down}, Position { int row, int col } начална точка, int health = големина и bool IsAlive = големина > 0.

Char\-овете са:

- \' \' за вода (Space)
- | за вертикален кораб \(видимо само на твоята матрица\)
- \- за хоризонтален кораб \(видимо само на твоята матрица\)
- x за уцелена вода [\*](#view)//Стефан: Предлагам char-a за уцелена вода да е 'М',защото малкия и големият Х ще се бъркат ! 
- X за уцелен кораб [\*](#view) 

Самолетоносач - 5к.
Няк`ъв друг кораб - 4к.
Крайцер - 3к.
Подводница - 3к.
Унищожител - 2к.

Когато всичко е готово се файърва евент и започва **първата част от играта**. Дисплейват се матриците на човека плейър. Някъде из болонезето се сетват променливи currentPlayer = Човека плейър, otherPlayer = Компютъра плейър.
Излиза текст: "Place your \[ShipName\] \(\[ShipLength\]\). Ex format: A1 Left"
Пишеш си командата, ако сбъркаш формата те връща със съобщение за грешка, ако няма място за кораба, щото има друг кораб или си достигнал ръба на матрицата **енджинът** те връща със съобщение за грешка. 
Като си разположиш всичките кораби се файърва евент, че си готов, currentPlayer и otherPlayer се флипват. компютъра също ги разполага, може би по някой [алгоритъм](#algorithm), може случайно, може и по готова схема, която ще се лоудне от файл.
Като си ги разположи се файърва евент, че е готов плейърите се флипват и започва **втората част от играта**.

Излиза текст: "Fire!!! Ex format: A1"
Пишеш си командата, ако сбъркаш формата те връща със съобщение за грешка, ако вече си стрелял на тая позиция енджинът те връща със съобщение за грешка *\(защото сме милостиви\)*. 
Енджинът проверява и нанася x или X на матрицата на otherPlayer и референтната матрица на currentPlayer според дали има кораб. Ако има нужда Ship.Health\-\-. 
-Ако otherPlayer е останал без кораби се файърва евент, currentPlayer става победител, на база изминалите ходове и оставащите му кораби се изчислява някакъв score, който може да се сравни с някакъв файл highscore.btl примерно и да те пита за име. 
-Ако не, currentPlayer и otherPlayer се флипват и се файърва евент и компютъра стреля, може би по някой [алгоритъм](#algorithm), може и случайно.

**\[14.12.2017, 19:50\]**Орлин: *Сори, повече не мога да пиша в момента, сядам на трапезата.*