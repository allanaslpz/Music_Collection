using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Music.Data
{
    public static class ExtraMigration
    {
        public static void Steps(MigrationBuilder migrationBuilder)
        {
            //Triggers for Musician
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER SetMusicianTimestampOnUpdate
                    AFTER UPDATE ON Musicians
                    BEGIN
                        UPDATE Musicians
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER SetMusicianTimestampOnInsert
                    AFTER INSERT ON Musicians
                    BEGIN
                        UPDATE Musicians
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");

            //Triggers for Album
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER SetAlbumTimestampOnUpdate
                    AFTER UPDATE ON Albums
                    BEGIN
                        UPDATE Albums
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER SetAlbumTimestampOnInsert
                    AFTER INSERT ON Albums
                    BEGIN
                        UPDATE Albums
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");

            //Triggers for Song
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER SetSongTimestampOnUpdate
                    AFTER UPDATE ON Songs
                    BEGIN
                        UPDATE Songs
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");
            migrationBuilder.Sql(
                @"
                    CREATE TRIGGER SetSongTimestampOnInsert
                    AFTER INSERT ON Songs
                    BEGIN
                        UPDATE Songs
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");
            //count performance fee
            migrationBuilder.Sql(
                @"
                    Create View PerformanceFeeSummaries as
                    Select p.ID, p.FirstName, p.MiddleName, p.LastName, Count(*) as NumberOfPerformances, 
	                    Avg(a.FeePaid) as AverageFeePaid, Max(a.FeePaid) as MaximumFeePaid, Min(a.FeePaid) as MinimumFeePaid
                    From Musicians p Join Performances a
                    on p.ID = a.MusicianID
                    Group By p.ID, p.FirstName, p.MiddleName, p.LastName
                ");
        }
    }
}
