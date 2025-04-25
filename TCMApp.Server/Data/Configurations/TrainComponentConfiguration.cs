using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCMApp.Server.Core.Entities;

namespace TCMApp.Server.Data.Configurations;

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
        builder.HasData(
        [
            new TrainComponent("Engine", "ENG123", false) { Id = 1},
            //new TrainComponent("Passenger Car", "PAS456", false),
            //new TrainComponent("Freight Car", "FRT789", false),
            //new TrainComponent("Wheel", "WHL101", true, 68),
            //new TrainComponent("Seat", "STS234", true, 59),
            //new TrainComponent("Window", "WIN567", true, 15),
            //new TrainComponent("Door", "DR123", true, 71),
            //new TrainComponent("Control Panel", "CTL987", true, 82),
            //new TrainComponent("Light", "LGT456", true, 65),
            //new TrainComponent("Brake", "BRK789", true, 50),
            //new TrainComponent("Bolt", "BLT321", true, 6),
            //new TrainComponent("Nut", "NUT654", true, 26),
            //new TrainComponent("Engine Hood", "EH789", false),
            //new TrainComponent("Axle", "AX456", false),
            //new TrainComponent("Piston", "PST789", false),
            //new TrainComponent("Handrail", "HND234", true, 49),
            //new TrainComponent("Step", "STP567", true, 86),
            //new TrainComponent("Roof", "RF123", false),
            //new TrainComponent("Air Conditioner", "AC789", false),
            //new TrainComponent("Flooring", "FLR456", false),
            //new TrainComponent("Mirror", "MRR789", true, 7),
            //new TrainComponent("Horn", "HRN321", false),
            //new TrainComponent("Coupler", "CPL654", false),
            //new TrainComponent("Hinge", "HNG987", true, 43),
            //new TrainComponent("Ladder", "LDR456", true, 53),
            //new TrainComponent("Paint", "PNT789", false),
            //new TrainComponent("Decal", "DCL321", true, 23),
            //new TrainComponent("Gauge", "GGS654", true, 10),
            //new TrainComponent("Battery", "BTR987", false),
            //new TrainComponent("Radiator", "RDR456", false)
        ]);
    }
}
