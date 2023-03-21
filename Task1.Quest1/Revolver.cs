namespace Task1.Quest1;

public class Revolver
{
    public int[] clip = new int[6] ;
    public int pointer = 0;
    public Revolver()
    {
        for (int i = 0; i < clip.Length; i++)
        {
            clip[i] = 0;
        }
    }

    public void scroll()
    {
        pointer = new Random().Next(0, 5);
    }
    
    public void unload( int flag)
    {
        if (flag == 0)
        {
            int temp = pointer;
            int counter = 0;
            while (counter != 6)
            {
                if (clip[temp % 6] != 0)
                {
                    Console.Write($"{clip[temp % 6]} ");
                }

                temp++;
                counter++;
            }

            Console.WriteLine($"\n");
        }
        else if (flag == 1)
        {
            Console.WriteLine($"{clip[pointer]}");
            Console.WriteLine($"\n");
        }
        else
        {
            {
                Console.WriteLine($"Некорректно введен аргумент, введите 0 для вывода всех эл-ов, 1 для одного");
                Console.WriteLine($"\n");
            }
        }
    }
    
    public void shoot()
    {
        clip[pointer] = 0;
        while (clip[pointer % 6] == 0)
        {
            pointer += 1;
        }

        pointer = pointer % 6;

    }
    public void print()
    {
        for (int i = 0; i < clip.Length; i++)
        {
            Console.Write($"{clip[i]} ");
        }
        Console.WriteLine('\n');
    }
    

    public bool AddOneBullet(int number)
    {
        for (int i = 0; i < clip.Length; i++)
        {
            if (clip[i] == 0)
            {
                clip[i] = number;
                pointer = i;
                return true;
            }
        }
        return false;
    }


    public bool AddBullet(int[] numbers)
    {
        int flag = 0;
        for (int j = 0; j < numbers.Length; j++)
        {
            for (int i = 0; i < clip.Length; i++)
            {
                if (clip[i] == 0 )
                {
                    clip[i] = numbers[j];
                    flag = 1;
                    pointer = i;
                    break;
                }

                
            }
            
        }
        if (flag == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}