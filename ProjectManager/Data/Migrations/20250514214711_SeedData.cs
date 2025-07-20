using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedDate", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 13, 14, 35, 11, 90, DateTimeKind.Utc).AddTicks(3994), "System zarządzania treścią w .NET dla blogów technologicznych", "CMS dla blogerów" },
                    { 2, new DateTime(2025, 5, 9, 4, 59, 11, 90, DateTimeKind.Utc).AddTicks(3999), "Moduł zarządzania zasobami i rezerwacjami dla wypożyczalni aparatów natychmiastowych", "ERP dla wypożyczalni sprzętu" },
                    { 3, new DateTime(2025, 5, 4, 12, 11, 11, 90, DateTimeKind.Utc).AddTicks(4001), "Aplikacja do analizy i wizualizacji wyników finansowych dla małych firm", "Analiza finansowa" },
                    { 4, new DateTime(2025, 5, 11, 0, 11, 11, 90, DateTimeKind.Utc).AddTicks(4003), "Platforma do tworzenia i zarządzania quizami edukacyjnymi dla Funduszu Młodzieżowego", "System quizów edukacyjnych" },
                    { 5, new DateTime(2025, 5, 2, 16, 59, 11, 90, DateTimeKind.Utc).AddTicks(4004), "System wspierający monitorowanie procesu produkcji okien z funkcją raportowania", "Monitoring produkcji okien" },
                    { 6, new DateTime(2025, 5, 7, 19, 23, 11, 90, DateTimeKind.Utc).AddTicks(4006), "Aplikacja CRM z funkcją zarządzania relacjami z klientami i automatyzacją procesów sprzedaży", "CRM dla małych firm" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "Id", "Description", "DueDate", "IsCompleted", "ProjectId", "Title" },
                values: new object[,]
                {
                    { 1, "Implementacja logowania i rejestracji użytkowników.", new DateTime(2025, 5, 19, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4037), false, 1, "Stworzenie modułu autoryzacji" },
                    { 2, "Wdrożenie edytora WYSIWYG do tworzenia postów.", new DateTime(2025, 5, 22, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4040), false, 1, "Integracja edytora tekstu" },
                    { 3, "Implementacja tagów i kategorii dla postów.", new DateTime(2025, 5, 24, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4041), true, 1, "Dodanie funkcji tagowania" },
                    { 4, "Przygotowanie testów jednostkowych dla CRUD postów.", new DateTime(2025, 5, 26, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4042), false, 1, "Testy jednostkowe modułu postów" },
                    { 5, "Zoptymalizowanie zapytań SQL dla modułu postów.", new DateTime(2025, 5, 29, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4044), false, 1, "Optymalizacja bazy danych" },
                    { 6, "Implementacja formularza rezerwacji sprzętu.", new DateTime(2025, 5, 21, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4046), false, 2, "Stworzenie modułu rezerwacji" },
                    { 7, "Wdrożenie funkcji generowania faktur po zakończeniu wypożyczenia.", new DateTime(2025, 5, 24, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4047), true, 2, "Generowanie faktur" },
                    { 8, "Podłączenie bramki płatności Stripe.", new DateTime(2025, 5, 26, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4049), false, 2, "Integracja płatności online" },
                    { 9, "Przeprowadzenie testów end-to-end dla modułu rezerwacji.", new DateTime(2025, 5, 28, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4050), false, 2, "Testy funkcjonalne modułu wypożyczeń" },
                    { 10, "Wygenerowanie raportów o najczęściej wypożyczanym sprzęcie.", new DateTime(2025, 6, 3, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4052), false, 2, "Analiza danych użytkowników" },
                    { 11, "Stworzenie modułu importu danych z plików CSV.", new DateTime(2025, 5, 17, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4053), false, 3, "Zaimportowanie danych finansowych" },
                    { 12, "Implementacja dashboardu z wizualizacją danych.", new DateTime(2025, 5, 20, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4054), false, 3, "Tworzenie dashboardu" },
                    { 13, "Poprawa wydajności analizy danych finansowych.", new DateTime(2025, 5, 23, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4055), true, 3, "Optymalizacja algorytmu analizy danych" },
                    { 14, "Generowanie raportu finansowego w formacie PDF.", new DateTime(2025, 5, 26, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4057), false, 3, "Tworzenie raportu PDF" },
                    { 15, "Napisanie testów jednostkowych dla modułu analizy finansowej.", new DateTime(2025, 5, 29, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4058), false, 3, "Testy jednostkowe dla algorytmu analizy" },
                    { 16, "Implementacja formularza dodawania nowego quizu.", new DateTime(2025, 5, 19, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4059), false, 4, "Tworzenie formularza quizu" },
                    { 17, "Zaimportowanie zestawu pytań z pliku CSV.", new DateTime(2025, 5, 22, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4060), true, 4, "Stworzenie bazy pytań" },
                    { 18, "Testowanie quizów w trybie użytkownika.", new DateTime(2025, 5, 24, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4062), false, 4, "Testy funkcjonalne quizów" },
                    { 19, "Implementacja modułu wyników z oceną quizu.", new DateTime(2025, 5, 28, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4063), false, 4, "Dodanie wyników quizu" },
                    { 20, "Poprawienie wydajności zapytań do bazy quizów.", new DateTime(2025, 6, 1, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4064), false, 4, "Optymalizacja bazy danych quizów" },
                    { 21, "Implementacja funkcji raportowania produkcji.", new DateTime(2025, 5, 21, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4066), false, 5, "Integracja modułu raportowania" },
                    { 22, "Testowanie generowanych raportów produkcyjnych.", new DateTime(2025, 5, 24, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4067), true, 5, "Testy modułu raportowania" },
                    { 23, "Wdrożenie systemu powiadomień o błędach produkcji.", new DateTime(2025, 5, 27, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4068), false, 5, "Powiadomienia o błędach" },
                    { 24, "Dodanie wykresu produkcji na dashboardzie.", new DateTime(2025, 5, 30, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4069), false, 5, "Wizualizacja produkcji w czasie rzeczywistym" },
                    { 25, "Sprawdzenie bezpieczeństwa danych produkcyjnych.", new DateTime(2025, 6, 3, 21, 47, 11, 90, DateTimeKind.Utc).AddTicks(4070), false, 5, "Audyt bezpieczeństwa danych" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Projects");
        }
    }
}
