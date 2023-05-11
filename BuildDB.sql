CREATE TABLE [User Account] (
    user_id INT PRIMARY KEY,
    name VARCHAR(50),
    date_of_birth DATE,
    phone VARCHAR(20),
    email VARCHAR(50)
);

CREATE TABLE User_Role (
    user_id INT,
    role INT,
    FOREIGN KEY (user_id) REFERENCES [User Account](user_id)
);

CREATE TABLE Student (
    student_id INT PRIMARY KEY,
    student_name VARCHAR(50),
    date_of_birth DATE,
    address VARCHAR(100),
    parent1_id INT,
    parent2_id INT,
    FOREIGN KEY (parent1_id) REFERENCES [User Account](user_id),
    FOREIGN KEY (parent2_id) REFERENCES [User Account](user_id)
);

CREATE TABLE Monthly_Attendance (
    attendance_id INT PRIMARY KEY,
    date DATE,
    student_id INT,
    status VARCHAR(20),
    FOREIGN KEY (student_id) REFERENCES Student(student_id)
);
