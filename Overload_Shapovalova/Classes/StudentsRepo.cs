using System;
using System.Collections.Generic;
using System.Linq;

namespace Overload_Shapovalova.Classes
{
    public class StudentsRepo
    {
        private List<string> students = new List<string>();

        public StudentsRepo()
        {
            students.Add("Иванов Иван");
            students.Add("Петров Петр");
            students.Add("Сидорова Анна");
            students.Add("Кузнецов Алексей");
            students.Add("Смирнова Ольга");
        }

        public int Count
        {
            get { return students.Count; }
        }

        public void AddName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return;

            name = name.Trim();
            if (students.Contains(name))
            {
                throw new Exception("Такой студент уже есть!");
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
            return students;
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

            return string.Join(separator, students);
        }

        public string PrintNames(string separator, bool sort)
        {
            return PrintNames(separator, sort, false);
        }

        public string PrintNames(string separator, bool sort, bool reverse)
        {
            if (string.IsNullOrEmpty(separator)) separator = ",";
            if (students.Count == 0) return "Список студентов пуст";

            List<string> list = new List<string>(students);
            if (sort) list.Sort();
            if (reverse) list.Reverse();

            return string.Join(separator, list);
        }

        public string PrintNames(string separator, int maxCount)
        {
            if (string.IsNullOrEmpty(separator)) separator = ",";
            if (students.Count == 0) return "Список студентов пуст";

            return string.Join(separator, students.Take(maxCount));
        }
        public void LoadFromFile(string path)
        {
            if (!System.IO.File.Exists(path)) return;
            students.Clear();
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                    students.Add(line.Trim());
            }
        }

        public string PrintNames(string separator, string path)
        {
            if (string.IsNullOrEmpty(separator)) separator = ",";
            string result = string.Join(separator, students);
            System.IO.File.WriteAllText(path, result);
            return result;
        }

        public List<string> SearchByName(string fragment)
        {
            if (string.IsNullOrWhiteSpace(fragment)) return new List<string>();
            return students.FindAll(s => s.IndexOf(fragment, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}