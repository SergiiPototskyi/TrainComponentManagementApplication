using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCMApp.Core.Entities;

namespace TCMApp.Infrastructure.Configurations
{
    public class TrainComponentConfiguration : IEntityTypeConfiguration<TrainComponent>
    {
        public void Configure(EntityTypeBuilder<TrainComponent> builder)
        {
            builder.ToTable("TrainComponents", Schemas.Default);

            builder.HasKey(tc => tc.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(tc => tc.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(tc => tc.UniqueNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(tc => tc.CanAssignQuantity)
                .IsRequired();

            builder
                .Property(tc => tc.Quantity)
                .IsRequired(false);

            builder
                .HasIndex(e => e.UniqueNumber)
                .IsUnique();

            // Seed data for testing
            // TODO: Remove this in production
            builder.HasData(
            [
                new TrainComponent("Engine", "ENG123", false) { Id = 1 },
                new TrainComponent("Passenger Car", "PAS456", false) { Id = 2 },
                new TrainComponent("Freight Car", "FRT789", false) { Id = 3 },
                new TrainComponent("Wheel", "WHL101", true, 68) { Id = 4 },
                new TrainComponent("Seat", "STS234", true, 59) { Id = 5 },
                new TrainComponent("Window", "WIN567", true, 15) { Id = 6 },
                new TrainComponent("Door", "DR123", true, 71) { Id = 7 },
                new TrainComponent("Control Panel", "CTL987", true, 82) { Id = 8 },
                new TrainComponent("Light", "LGT456", true, 65) { Id = 9 },
                new TrainComponent("Brake", "BRK789", true, 50) { Id = 10 },
                new TrainComponent("Bolt", "BLT321", true, 6) { Id = 11 },
                new TrainComponent("Nut", "NUT654", true, 26) { Id = 12 },
                new TrainComponent("Engine Hood", "EH789", false) { Id= 13 },
                new TrainComponent("Axle", "AX456", false) { Id = 14 },
                new TrainComponent("Piston", "PST789", false) { Id = 15 },
                new TrainComponent("Handrail", "HND234", true, 49) { Id = 16 },
                new TrainComponent("Step", "STP567", true, 86) { Id = 17 },
                new TrainComponent("Roof", "RF123", false) { Id = 18 },
                new TrainComponent("Air Conditioner", "AC789", false) { Id = 19 },
                new TrainComponent("Flooring", "FLR456", false) { Id = 20 },
                new TrainComponent("Mirror", "MRR789", true, 7) { Id = 21 },
                new TrainComponent("Horn", "HRN321", false) { Id = 22 },
                new TrainComponent("Coupler", "CPL654", false) { Id = 23 },
                new TrainComponent("Hinge", "HNG987", true, 43) { Id = 24 },
                new TrainComponent("Ladder", "LDR456", true, 53) { Id = 25 },
                new TrainComponent("Paint", "PNT789", false) { Id = 26 },
                new TrainComponent("Decal", "DCL321", true, 23) { Id = 27 },
                new TrainComponent("Gauge", "GGS654", true, 10) { Id = 28 },
                new TrainComponent("Battery", "BTR987", false) { Id = 29 },
                new TrainComponent("Radiator", "RDR456", false) { Id = 30 }
            ]);
        }
    }
}
