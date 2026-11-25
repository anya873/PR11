using System;
using System.Collections.Generic;
using System.Linq;

namespace Overload_Shapovalova.Classes
{
    public class StudentsRepo
    {
        private List<string> students;

        public int Count => students.Count;

        public StudentsRepo()
        {
            students = new List<string>
            {
                "Иванов Иван",
                "Петров Петр",
                "Сидорова Анна",
                "Кузнецов Алексей",
                "Смирнова Ольга"
            };
        }

        public void AddName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return;
            name = name.Trim();
            if (students.Any(s => s.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("Студент с таким ФИО уже есть в списке.");
            }
            students.Add(name);
        }

        public void RemoveName(string name)
        {
            students.Remove(name);
        }

        public void Clear()
        {
            students.Clear();
        }

        public List<string> GetNames()
        {
            return new List<string>(students);
        }

        public string PrintNames()
        {
            return PrintNames(",");
        }

        public string PrintNames(char separator)
        {
            return PrintNames(separator.ToString());
        }

        public string PrintNames(string separator)
        {
            if (string.IsNullOrEmpty(separator)) separator = ",";
            if (students.Count == 0) return "Список студентов пуст";
            return string.Join(separator, students.Select(s => s.Trim()));
        }

        public string PrintNames(string separator, bool sort)
        {
            return PrintNames(separator, sort, false);
        }

        public string PrintNames(string separator, bool sort, bool reverse)
        {
            if (string.IsNullOrEmpty(separator)) separator = ",";
            if (students.Count == 0) return "Список студентов пуст";

            var list = students.Select(s => s.Trim()).ToList();
            if (sort) list.Sort();
            if (reverse) list.Reverse();

            return string.Join(separator, list);
        }

        public string PrintNames(string separator, int maxCount)
        {
            if (string.IsNullOrEmpty(separator)) separator = ",";
            if (students.Count == 0) return "Список студентов пуст";

            return string.Join(separator, students.Take(maxCount).Select(s => s.Trim()));
        }
    }
}