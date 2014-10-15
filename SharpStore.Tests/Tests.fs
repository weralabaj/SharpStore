namespace Tests

open NUnit.Framework
open Shop

[<TestFixture>]
type TestClass() =
    [<Test>]
    let abcdef () = 
        Assert.AreEqual(2+2, 4)

