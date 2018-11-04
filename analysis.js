function person (age, race, gender, education, name){
    this.age = age;
    this.race = race;
    this.gender = gender;
    this.education = education;
    this.name = name;
}

person.prototype.report = function(){
    console.log("reporting");
    var msg = `${this.name} is a ${this.age} year old ${this.race} ${this.gender} with a degree from ${this.education}`;
    console.log(msg);
    return this;
}

person.prototype.changeschool = function(school){
    this.education = school;
    // report here
    this.report();
    return this;
}

var maxwell = new person(27, 'white', 'male', 'ucsc', "maxwell");
maxwell.report();
maxwell.changeschool("Coding Dojo");