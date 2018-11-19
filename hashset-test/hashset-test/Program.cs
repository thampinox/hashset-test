using System;
using System.Collections.Generic;

namespace hashset_test {
  class Program {
    static void Main(string[] args) {
      var myClassList = new List<MyClass>
      {
        new MyClass { Id1 = 1, Id2 = 2, Comments = "test1" },
        new MyClass { Id1 = 1, Id2 = 2, Comments = "test1" },
        new MyClass { Id1 = 2, Id2 = 4, Comments = "test2" }
      };

      var hashSet1 = new HashSet<MyClass>();

      foreach (var myClass in myClassList) {
        if (!hashSet1.Add(myClass)) {
          Console.WriteLine($"My class with id1 - {myClass.Id1} and id2 - {myClass.Id2} already exist");
        }
      }

      Console.ReadKey();
    }
  }

  class MyClass : IEquatable<MyClass> {
    public long Id1;
    public long Id2;
    public string Comments;

    public override bool Equals(object obj) {
      return Equals(obj as MyClass);
    }

    public bool Equals(MyClass other) {
      return other != null &&
             Id1 == other.Id1 &&
             Id2 == other.Id2;
    }

    public override int GetHashCode() {
      return HashCode.Combine(Id1, Id2);
    }
  }
}
