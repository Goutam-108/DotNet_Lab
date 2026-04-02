using System;

internal class Animal
{
    string name;
    int age;

    public void setName(string name)
    {
        this.name = name;
    }
    public void setAge(int age)
    {
        this.age = age;
    }
    public string getName()
    {
        return name;
    }
    public int getAge()
    {
        return age;
    }
};

class OOP
{
    public static void main()
    {
        Animal tf = new Animal();
        Console.WriteLine(tf.getName());
        Console.WriteLine(tf.getAge());
        
    }
}