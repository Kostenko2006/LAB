using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    public class HospitalDemo
    {
        public void Run()
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===\n");

            Hospital hospital = new Hospital();

            Console.WriteLine("--- ДОДАВАННЯ ЛІКАРІВ ---");
            Doctor doctor1 = new Doctor(1, "Петренко Андрій", "Травматолог");
            Doctor doctor2 = new Doctor(2, "Коваленко Софія", "Педіатр");
            Doctor doctor3 = new Doctor(3, "Лисенко Василь", "Невролог");

            hospital.AddDoctor(doctor1);
            hospital.AddDoctor(doctor2);
            hospital.AddDoctor(doctor3);

            Console.WriteLine("\n--- РЕЄСТРАЦІЯ ПАЦІЄНТІВ ---");
            Patient patient1 = new Patient(1, "Марченко Оксана", 35);
            Patient patient2 = new Patient(2, "Шевчук Дмитро", 67);
            Patient patient3 = new Patient(3, "Бойко Анна", 8);
            Patient patient4 = new Patient(4, "Ткаченко Сергій", 42);

            hospital.RegisterPatient(patient1);
            hospital.RegisterPatient(patient2);
            hospital.RegisterPatient(patient3);
            hospital.RegisterPatient(patient4);

            Console.WriteLine("\n--- СТВОРЕННЯ ПАЛАТ ---");
            HospitalRoom room101 = new HospitalRoom(101, 2);
            HospitalRoom room102 = new HospitalRoom(102, 3);
            HospitalRoom room201 = new HospitalRoom(201, 1);

            hospital.CreateRoom(room101);
            hospital.CreateRoom(room102);
            hospital.CreateRoom(room201);

            Console.WriteLine("\n--- ГОСПІТАЛІЗАЦІЯ ПАЦІЄНТІВ ---");
            hospital.HospitalizePatient(1, 101);
            hospital.HospitalizePatient(2, 101);
            hospital.HospitalizePatient(3, 102);
            hospital.HospitalizePatient(4, 102);
            hospital.HospitalizePatient(1, 201);

            Console.WriteLine("\n--- МЕДИЧНІ ЗАПИСИ ---");
            MedicalRecord record1 = new MedicalRecord(
                patient1, doctor1, new DateTime(2024, 1, 15),
                "Закритий перелом ліктьової кістки. Накладено гіпс."
            );
            MedicalRecord record2 = new MedicalRecord(
                patient2, doctor3, new DateTime(2024, 1, 16),
                "Гострий порушення мозкового кровообігу. Стаціонарне лікування."
            );
            MedicalRecord record3 = new MedicalRecord(
                patient3, doctor2, new DateTime(2024, 1, 17),
                "Гострий бронхіт. Призначені інгаляції та антибіотикотерапія."
            );
            MedicalRecord record4 = new MedicalRecord(
                patient4, doctor1, new DateTime(2024, 1, 18),
                "Розтягнення зв'язок колінного суглоба. Фізіотерапія."
            );

            hospital.AddMedicalRecord(record1);
            hospital.AddMedicalRecord(record2);
            hospital.AddMedicalRecord(record3);
            hospital.AddMedicalRecord(record4);

            Console.WriteLine("\n--- ІСТОРІЯ ПАЦІЄНТА Марченко Оксана (ID: 1) ---");
            var history = hospital.GetPatientHistory(1);
            foreach (var record in history)
            {
                Console.WriteLine($"  Дата: {record.Date.ToShortDateString()}");
                Console.WriteLine($"  Лікар: {record.Doctor.Name} ({record.Doctor.Specialization})");
                Console.WriteLine($"  Опис: {record.Description}\n");
            }

            Console.WriteLine("\n--- ІСТОРІЯ ПАЦІЄНТА Бойко Анна (ID: 3) ---");
            var history2 = hospital.GetPatientHistory(3);
            foreach (var record in history2)
            {
                Console.WriteLine($"  Дата: {record.Date.ToShortDateString()}");
                Console.WriteLine($"  Лікар: {record.Doctor.Name} ({record.Doctor.Specialization})");
                Console.WriteLine($"  Опис: {record.Description}\n");
            }

            Console.WriteLine(hospital.GetStatistics());
        }
    }
}
