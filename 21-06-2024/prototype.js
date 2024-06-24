function Person(name, age) {
  this.name = name;
  this.age = age;
}

Person.prototype.getDetails = function () {
  return this.name + " is " + this.age + " years old.";
};

function Student(name, age, grade) {
  Person.call(this, name, age); // Call super constructor
  this.grade = grade;
}

Student.prototype.getStudentDetails = function () {
  return (
    this.name +
    " is " +
    this.age +
    " years old and is in grade " +
    this.grade +
    "."
  );
};

var person1 = new Person("John", 30);
console.log(person1.getDetails());

var student1 = new Student("Jane", 18, 12);
console.log(student1.getStudentDetails());
