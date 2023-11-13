package org.example;

public class Calculator {
    public String Sum(String a, String b) {
        int newA, newB, result;
        try {
            newA = Integer.parseInt(a);
            newB = Integer.parseInt(b);
            result = newA + newB;
            return Integer.toString((int)result);
        }
        catch (Exception exception) {
            return "Error parsing";
        }
    }
    public String Dif(String a, String b) {
        int newA, newB, result;
        try {
            newA = Integer.parseInt(a);
            newB = Integer.parseInt(b);
            result = newA - newB;
            return Integer.toString((int)result);
        }
        catch (Exception exception) {
            return "Error parsing";
        }
    }
    public String Mul(String a, String b) {
        int newA, newB, result;
        try {
            newA = Integer.parseInt(a);
            newB = Integer.parseInt(b);
            result = newA * newB;
            return Integer.toString((int)result);
        }
        catch (Exception exception) {
            return "Error parsing";
        }
    }
    public String Div(String a, String b) {
        int newA, newB, result;
        try {
            newA = Integer.parseInt(a);
            newB = Integer.parseInt(b);
            result = newA / newB;
            return Integer.toString((int)result);
        }
        catch (Exception exception) {
            return "Error parsing";
        }
    }
}
