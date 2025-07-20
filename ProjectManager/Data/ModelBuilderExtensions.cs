using Microsoft.EntityFrameworkCore;
using ProjectManager.Data.Models;

namespace ProjectManager.Data
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigureProject(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(p => p.CreateDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Project>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Project>()
                .Property(p => p.Description)
                .IsRequired(false)
                .HasMaxLength(500);
        }

        public static void ConfigureProjectTask(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTask>()
               .ToTable("ProjectTasks");

            modelBuilder.Entity<ProjectTask>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectTasks)
                .HasForeignKey(pt => pt.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectTask>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<ProjectTask>()
                .Property(p => p.Description)
                .IsRequired(false);

            modelBuilder.Entity<ProjectTask>()
                 .Property(p => p.IsCompleted)
                .IsRequired();
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            var projects = new List<Project>
            {
                new Project
                {
                    Id = 1,
                    Name = "CMS dla blogerów",
                    Description = "System zarządzania treścią w .NET dla blogów technologicznych",
                    CreatedDate = DateTime.UtcNow.AddDays(-1.3)
                },
                new Project
                {
                    Id = 2,
                    Name = "ERP dla wypożyczalni sprzętu",
                    Description = "Moduł zarządzania zasobami i rezerwacjami dla wypożyczalni aparatów natychmiastowych",
                    CreatedDate = DateTime.UtcNow.AddDays(-5.7)
                },
                new Project
                {
                    Id = 3,
                    Name = "Analiza finansowa",
                    Description = "Aplikacja do analizy i wizualizacji wyników finansowych dla małych firm",
                    CreatedDate = DateTime.UtcNow.AddDays(-10.4)
                },
                new Project
                {
                    Id = 4,
                    Name = "System quizów edukacyjnych",
                    Description = "Platforma do tworzenia i zarządzania quizami edukacyjnymi dla Funduszu Młodzieżowego",
                    CreatedDate = DateTime.UtcNow.AddDays(-3.9)
                },
                new Project
                {
                    Id = 5,
                    Name = "Monitoring produkcji okien",
                    Description = "System wspierający monitorowanie procesu produkcji okien z funkcją raportowania",
                    CreatedDate = DateTime.UtcNow.AddDays(-12.2)
                },
                new Project
                {
                    Id = 6,
                    Name = "CRM dla małych firm",
                    Description = "Aplikacja CRM z funkcją zarządzania relacjami z klientami i automatyzacją procesów sprzedaży",
                    CreatedDate = DateTime.UtcNow.AddDays(-7.1)
                }
            };

            modelBuilder.Entity<Project>().HasData(projects);

            var projectTasks = new List<ProjectTask>
            {
                // Tasks for Project 1 - CMS dla blogerów
                new ProjectTask { Id = 1, Title = "Stworzenie modułu autoryzacji", Description = "Implementacja logowania i rejestracji użytkowników.", DueDate = DateTime.UtcNow.AddDays(5), IsCompleted = false, ProjectId = 1 },
                new ProjectTask { Id = 2, Title = "Integracja edytora tekstu", Description = "Wdrożenie edytora WYSIWYG do tworzenia postów.", DueDate = DateTime.UtcNow.AddDays(8), IsCompleted = false, ProjectId = 1 },
                new ProjectTask { Id = 3, Title = "Dodanie funkcji tagowania", Description = "Implementacja tagów i kategorii dla postów.", DueDate = DateTime.UtcNow.AddDays(10), IsCompleted = true, ProjectId = 1 },
                new ProjectTask { Id = 4, Title = "Testy jednostkowe modułu postów", Description = "Przygotowanie testów jednostkowych dla CRUD postów.", DueDate = DateTime.UtcNow.AddDays(12), IsCompleted = false, ProjectId = 1 },
                new ProjectTask { Id = 5, Title = "Optymalizacja bazy danych", Description = "Zoptymalizowanie zapytań SQL dla modułu postów.", DueDate = DateTime.UtcNow.AddDays(15), IsCompleted = false, ProjectId = 1 },

                // Tasks for Project 2 - ERP dla wypożyczalni sprzętu
                new ProjectTask { Id = 6, Title = "Stworzenie modułu rezerwacji", Description = "Implementacja formularza rezerwacji sprzętu.", DueDate = DateTime.UtcNow.AddDays(7), IsCompleted = false, ProjectId = 2 },
                new ProjectTask { Id = 7, Title = "Generowanie faktur", Description = "Wdrożenie funkcji generowania faktur po zakończeniu wypożyczenia.", DueDate = DateTime.UtcNow.AddDays(10), IsCompleted = true, ProjectId = 2 },
                new ProjectTask { Id = 8, Title = "Integracja płatności online", Description = "Podłączenie bramki płatności Stripe.", DueDate = DateTime.UtcNow.AddDays(12), IsCompleted = false, ProjectId = 2 },
                new ProjectTask { Id = 9, Title = "Testy funkcjonalne modułu wypożyczeń", Description = "Przeprowadzenie testów end-to-end dla modułu rezerwacji.", DueDate = DateTime.UtcNow.AddDays(14), IsCompleted = false, ProjectId = 2 },
                new ProjectTask { Id = 10, Title = "Analiza danych użytkowników", Description = "Wygenerowanie raportów o najczęściej wypożyczanym sprzęcie.", DueDate = DateTime.UtcNow.AddDays(20), IsCompleted = false, ProjectId = 2 },

                // Tasks for Project 3 - Analiza finansowa
                new ProjectTask { Id = 11, Title = "Zaimportowanie danych finansowych", Description = "Stworzenie modułu importu danych z plików CSV.", DueDate = DateTime.UtcNow.AddDays(3), IsCompleted = false, ProjectId = 3 },
                new ProjectTask { Id = 12, Title = "Tworzenie dashboardu", Description = "Implementacja dashboardu z wizualizacją danych.", DueDate = DateTime.UtcNow.AddDays(6), IsCompleted = false, ProjectId = 3 },
                new ProjectTask { Id = 13, Title = "Optymalizacja algorytmu analizy danych", Description = "Poprawa wydajności analizy danych finansowych.", DueDate = DateTime.UtcNow.AddDays(9), IsCompleted = true, ProjectId = 3 },
                new ProjectTask { Id = 14, Title = "Tworzenie raportu PDF", Description = "Generowanie raportu finansowego w formacie PDF.", DueDate = DateTime.UtcNow.AddDays(12), IsCompleted = false, ProjectId = 3 },
                new ProjectTask { Id = 15, Title = "Testy jednostkowe dla algorytmu analizy", Description = "Napisanie testów jednostkowych dla modułu analizy finansowej.", DueDate = DateTime.UtcNow.AddDays(15), IsCompleted = false, ProjectId = 3 },

                // Tasks for Project 4 - System quizów edukacyjnych
                new ProjectTask { Id = 16, Title = "Tworzenie formularza quizu", Description = "Implementacja formularza dodawania nowego quizu.", DueDate = DateTime.UtcNow.AddDays(5), IsCompleted = false, ProjectId = 4 },
                new ProjectTask { Id = 17, Title = "Stworzenie bazy pytań", Description = "Zaimportowanie zestawu pytań z pliku CSV.", DueDate = DateTime.UtcNow.AddDays(8), IsCompleted = true, ProjectId = 4 },
                new ProjectTask { Id = 18, Title = "Testy funkcjonalne quizów", Description = "Testowanie quizów w trybie użytkownika.", DueDate = DateTime.UtcNow.AddDays(10), IsCompleted = false, ProjectId = 4 },
                new ProjectTask { Id = 19, Title = "Dodanie wyników quizu", Description = "Implementacja modułu wyników z oceną quizu.", DueDate = DateTime.UtcNow.AddDays(14), IsCompleted = false, ProjectId = 4 },
                new ProjectTask { Id = 20, Title = "Optymalizacja bazy danych quizów", Description = "Poprawienie wydajności zapytań do bazy quizów.", DueDate = DateTime.UtcNow.AddDays(18), IsCompleted = false, ProjectId = 4 },

                // Tasks for Project 5 - Monitoring produkcji okien
                new ProjectTask { Id = 21, Title = "Integracja modułu raportowania", Description = "Implementacja funkcji raportowania produkcji.", DueDate = DateTime.UtcNow.AddDays(7), IsCompleted = false, ProjectId = 5 },
                new ProjectTask { Id = 22, Title = "Testy modułu raportowania", Description = "Testowanie generowanych raportów produkcyjnych.", DueDate = DateTime.UtcNow.AddDays(10), IsCompleted = true, ProjectId = 5 },
                new ProjectTask { Id = 23, Title = "Powiadomienia o błędach", Description = "Wdrożenie systemu powiadomień o błędach produkcji.", DueDate = DateTime.UtcNow.AddDays(13), IsCompleted = false, ProjectId = 5 },
                new ProjectTask { Id = 24, Title = "Wizualizacja produkcji w czasie rzeczywistym", Description = "Dodanie wykresu produkcji na dashboardzie.", DueDate = DateTime.UtcNow.AddDays(16), IsCompleted = false, ProjectId = 5 },
                new ProjectTask { Id = 25, Title = "Audyt bezpieczeństwa danych", Description = "Sprawdzenie bezpieczeństwa danych produkcyjnych.", DueDate = DateTime.UtcNow.AddDays(20), IsCompleted = false, ProjectId = 5 }
            };

            modelBuilder.Entity<ProjectTask>().HasData(projectTasks);
        }
    }
}
