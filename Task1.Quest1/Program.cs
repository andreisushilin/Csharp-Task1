﻿using Task1.Quest1;

Revolver Andrey = new Revolver();
Andrey.print();
int[] numbers = new int[] {0, 61, 555, 14 };
int[] numbers1 = new int[] { 1, 2 };
Andrey.AddBullet(numbers);
Andrey.print();
Andrey.AddBullet(numbers1);
Andrey.print();
Console.WriteLine($"Pointer = {Andrey.pointer}");
Andrey.pointer = 2;
Console.WriteLine($"Pointer = {Andrey.pointer}");
Andrey.unload(0);
Andrey.shoot();
Andrey.print();
Console.WriteLine($"{Andrey.pointer}");
Andrey.scroll();
Console.WriteLine($"{Andrey.pointer}");
Andrey.unload(1);