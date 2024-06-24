class Person {
  constructor(name, age) {
    this.name = name;
    this.age = age;
  }

  getDetails() {
    return `${this.name} is ${this.age} years old.`;
  }
}

class Student extends Person {
  constructor(name, age, grade) {
    super(name, age);
    this.grade = grade;
  }

  getStudentDetails() {
    return `${this.name} is ${this.age} years old and is in grade ${this.grade}.`;
  }
}

const person1 = new Person("Alice", 30);
console.log(person1.getDetails());

const student1 = new Student("Bob", 18, 12);
console.log(student1.getDetails());
console.log(student1.getStudentDetails());
