using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VkTask.Host.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Insert_user_admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var query = $"INSERT INTO public.\"User\" (\"Login\", \"Password\", \"CreatedDate\", \"UserGroupId\", \"UserStateId\") VALUES('admin', 'admin', '{DateTime.UtcNow}', 1, 1)";
            
            migrationBuilder.Sql(query);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
