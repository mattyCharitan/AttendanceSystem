# AttendanceSystem

This code is in development by mattyCharitan and hadasar1.

## Attendance System for Kids

Our Attendance System for Kids is designed to simplify the attendance tracking process in schools while keeping parents informed about their children's attendance. Leveraging facial recognition technology, the system automatically marks students as present when they enter the classroom. If a student is not marked present until the scheduled time, the system sends automatic notifications to their parents via email or text message. This system reduces administrative overhead, provides real-time attendance updates to parents, and enhances student safety by allowing only authorized individuals into the classroom.

## Features and Functions

* Sign-up and Login: Teachers and parents can create accounts and log in to access attendance data. (Implemented with C#.)
* Attendance Tracking: The system records attendance data for each student in a centralized database, allowing easy analysis of attendance trends. (Implemented with C#.)
  
* Student Entity Creation: Teachers can create a student entity in the system and upload labeled images of the student's face for the facial recognition system. (Implemented with C#.)
  
* Facial Recognition System: Utilizes a facial recognition algorithm to automatically recognize students upon entry. Compares captured images with labeled images in the database to mark students as present. (Implemented with Python face-recognition libraries.)
  
* Notification System: Automatically sends email or text notifications to parents if a student is not marked present by a certain time. Notifications include the student's name, class, and date and time of the absence. (Implemented with C#.)


