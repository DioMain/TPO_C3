package org.example;
import java.io.Console;
import java.util.Scanner;
public class Main {
    public static void main(String[] args) {

       while(true) {
           Scanner in = new Scanner(System.in);
           System.out.print("Input a: ");
           String a = in.nextLine();
           System.out.print("Input b: ");
           String b = in.nextLine();
           System.out.print("Input operation: ");
           String operation = in.nextLine();
           System.out.println("result = " + Calculation(a, b, operation));
       }


    }

    public static String Calculation(String a, String b, String operation) {
        try {
            Calculator calculator = new Calculator();
            if (operation.equals("+"))
                return calculator.Sum(a, b);
            else if (operation.equals("-"))
                return calculator.Dif(a, b);
            else if (operation.equals("*"))
                return calculator.Mul(a, b);
            else if (operation.equals("/"))
                return calculator.Div(a, b);
            else {
                throw new RuntimeException("Error operator");
            }

        } catch (Exception exception) {
            return exception.getMessage();
        }

    }
}