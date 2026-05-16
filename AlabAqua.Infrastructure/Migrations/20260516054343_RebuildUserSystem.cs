using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlabAqua.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RebuildUserSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Drop old foreign keys (ignore if missing)
            migrationBuilder.Sql("ALTER TABLE `ModerationLogs` DROP FOREIGN KEY `FK_ModerationLogs_Users_ModeratorId`;", suppressTransaction: true);
            migrationBuilder.Sql("ALTER TABLE `SpeciesMedia` DROP FOREIGN KEY `FK_SpeciesMedia_Users_UploadedBy`;", suppressTransaction: true);
            migrationBuilder.Sql("ALTER TABLE `Articles` DROP FOREIGN KEY `FK_Articles_Users_AuthorId`;", suppressTransaction: true);
            migrationBuilder.Sql("ALTER TABLE `Posts` DROP FOREIGN KEY `FK_Posts_Users_UserId`;", suppressTransaction: true);
            migrationBuilder.Sql("ALTER TABLE `Tanks` DROP FOREIGN KEY `FK_Tanks_Users_UserId`;", suppressTransaction: true);
            migrationBuilder.Sql("ALTER TABLE `UserProfiles` DROP FOREIGN KEY `FK_UserProfiles_Users_UserId`;", suppressTransaction: true);

            // 2. Drop old indexes (ignore if missing)
            migrationBuilder.Sql("DROP INDEX `IX_SpeciesMedia_UploadedBy` ON `SpeciesMedia`;", suppressTransaction: true);
            migrationBuilder.Sql("DROP INDEX `IX_ModerationLogs_ModeratorId` ON `ModerationLogs`;", suppressTransaction: true);
            migrationBuilder.Sql("DROP INDEX `IX_Articles_AuthorId` ON `Articles`;", suppressTransaction: true);
            migrationBuilder.Sql("DROP INDEX `IX_Posts_UserId` ON `Posts`;", suppressTransaction: true);
            migrationBuilder.Sql("DROP INDEX `IX_Tanks_UserId` ON `Tanks`;", suppressTransaction: true);
            migrationBuilder.Sql("DROP INDEX `IX_UserProfiles_UserId` ON `UserProfiles`;", suppressTransaction: true);

            // 3. Drop old User columns
            migrationBuilder.DropColumn(name: "UserName", table: "Users");
            migrationBuilder.DropColumn(name: "Role", table: "Users");
            migrationBuilder.DropColumn(name: "IsActive", table: "Users");

            // 4. Fix UserProfile columns
            migrationBuilder.DropColumn(name: "CreatedAt", table: "UserProfiles");
            migrationBuilder.DropColumn(name: "DefaultContactEmail", table: "UserProfiles");
            migrationBuilder.DropColumn(name: "FacebookLink", table: "UserProfiles");
            migrationBuilder.DropColumn(name: "InstagramLink", table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "UserProfiles",
                newName: "JoinedDate");

            migrationBuilder.RenameColumn(
                name: "DefaultContactPhone",
                table: "UserProfiles",
                newName: "ExperienceLevel");

            // 5. Convert all FK columns to GUID (char(36))
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                type: "char(36)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Articles",
                type: "char(36)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Posts",
                type: "char(36)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Tanks",
                type: "char(36)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "UploadedBy",
                table: "SpeciesMedia",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModeratorId",
                table: "ModerationLogs",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserProfiles",
                type: "char(36)",
                nullable: false);

            // 6. Recreate indexes
            migrationBuilder.CreateIndex("IX_Articles_AuthorId", "Articles", "AuthorId");
            migrationBuilder.CreateIndex("IX_Posts_UserId", "Posts", "UserId");
            migrationBuilder.CreateIndex("IX_Tanks_UserId", "Tanks", "UserId");
            migrationBuilder.CreateIndex("IX_SpeciesMedia_UploadedBy", "SpeciesMedia", "UploadedBy");
            migrationBuilder.CreateIndex("IX_ModerationLogs_ModeratorId", "ModerationLogs", "ModeratorId");
            migrationBuilder.CreateIndex("IX_UserProfiles_UserId", "UserProfiles", "UserId");

            // 7. Recreate foreign keys
            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_AuthorId",
                table: "Articles",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tanks_Users_UserId",
                table: "Tanks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpeciesMedia_Users_UploadedBy",
                table: "SpeciesMedia",
                column: "UploadedBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ModerationLogs_Users_ModeratorId",
                table: "ModerationLogs",
                column: "ModeratorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Users_UserId",
                table: "UserProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

    }
}
