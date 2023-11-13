package testing;

import org.example.Calculator;
import org.example.Main;
import org.testng.Assert;
import org.testng.annotations.Test;

public class Tester {
    @Test
    public void Test1() {

        Assert.assertEquals(Main.Calculation("5fd","5", "+"),"Error parsing");
    }
    @Test
    public void Test2() {

        Assert.assertEquals(Main.Calculation("5","5", "a"),"Error operator");
    }
    @Test
    public void Test3() {

        Assert.assertEquals(Main.Calculation("5","5", "+"),"10");
    }
    @Test
    public void Test4() {

        Assert.assertEquals(Main.Calculation("5","5", "*"),"25");
    }
    @Test
    public void Test5() {

        Assert.assertEquals(Main.Calculation("5","5", "/"),"1");
    }
    @Test
    public void Test6() {

        Assert.assertEquals(Main.Calculation("5","5", "-"),"0");
    }
    @Test
    public void Test7() {
        Calculator calculator = new Calculator();
        Assert.assertEquals(calculator.Sum("5","5"),"10");
    }
    @Test
    public void Test8() {
        Calculator calculator = new Calculator();
        Assert.assertEquals(calculator.Sum("5Hello","5"),"Error parsing");
    }

    @Test
    public void Test9() {
        Calculator calculator = new Calculator();
        Assert.assertEquals(calculator.Dif("5","5"),"0");
    }
    @Test
    public void Test10() {
        Calculator calculator = new Calculator();
        Assert.assertEquals(calculator.Dif("5Hello","5"),"Error parsing");
    }

    @Test
    public void Test11() {
        Calculator calculator = new Calculator();
        Assert.assertEquals(calculator.Mul("5","5"),"25");
    }
    @Test
    public void Test12() {
        Calculator calculator = new Calculator();
        Assert.assertEquals(calculator.Mul("5Hello","5"),"Error parsing");
    }

    @Test
    public void Test13() {
        Calculator calculator = new Calculator();
        Assert.assertEquals(calculator.Div("5","5"),"1");
    }
    @Test
    public void Test14() {
        Calculator calculator = new Calculator();
        Assert.assertEquals(calculator.Div("5Hello","5"),"Error parsing");
    }



    @Test
    public void Test15() {

        Assert.assertEquals(Main.Calculation("5fd","5", "-"),"Error parsing");
    }
    @Test
    public void Test16() {

        Assert.assertEquals(Main.Calculation("5fd","5", "*"),"Error parsing");
    }
    @Test
    public void Test17() {

        Assert.assertEquals(Main.Calculation("5fd","5", "/"),"Error parsing");
    }
}
