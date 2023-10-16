import org.junit.Assert;
import org.junit.Test;

public class TestClass {

    @Test
    public void test0() {
        Assert.fail("Not Work");
    }

    @Test
    public void test1() {
        Assert.assertTrue("Is work!", true);
    }
}
