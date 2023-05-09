using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VkTask.Host.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Insert_groups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var query =
                $"INSERT INTO public.\"UserGroup\" (\"Code\", \"Description\") VALUES('Admin', 'К данной группе принадлежат пользователи с правами администратора.')," +
                "('User', 'К данной группе принадлежат пользователи с правами обычного пользователя.')";
            
            migrationBuilder.Sql(query);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
