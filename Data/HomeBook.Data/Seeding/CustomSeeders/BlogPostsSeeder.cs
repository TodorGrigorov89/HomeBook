namespace HomeBook.Data.Seeding.CustomSeeders
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Common;
    using HomeBook.Data.Models;

    public class BlogPostsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.BlogPosts.Any())
            {
                return;
            }

            var blogPosts = new BlogPost[]
                {
                    new BlogPost
                    {
                        Title = "Condominium Management Act",
                        Content = @"Effective from 01.05.2009

Prom. DV. issue 6 of 23 January 2009, amended DV. issue 15 of 23 February 2010,

ed. DV. issue 8 of 25 January 2011, amended DV. issue 57 of July 26, 2011

Chapter One.

GENERAL

Section I.

Subject of the law

Scope of the law

Art. 1. (Supplemented, SG No. 57/2011) This Act shall regulate the public relations related to the management of the common parts of buildings in condominium regime, as well as the rights and obligations of the owners, users and occupants of separate sites. or parts thereof.

Special mode of management of common areas

Art. 2. (1) The management of the common parts of buildings in condominium regime, built in a residential complex of closed type, shall be settled by a written contract with notarization of the signatures between the investor and the owners of separate sites.

(2) (Supplemented, SG No. 57/2011) The contract under para. 1 shall be entered by the investor in the Registry Agency on the account of each independent site and shall be opposed to its subsequent acquirers.

Exceptions

Art. 3. (Amended, SG No. 57/2011) The provisions of Art. 30, para. 3, Art. 31, para. 1 and Art. 32 of the Property Act.

Determining the adjacent area

Art. 4. (1) In case of restructuring of quarters with complex construction and in the cases when a building in condominium regime cannot be separated into a separate regulated land plot by the order of the Spatial Planning Act, the adjacent area to the building shall be determined.

(2) In the cases under par. 1, the adjacent area shall be determined by the mayor of the municipality on his initiative or at the request of the interested persons by an order determined by an ordinance.",
                        Author = GlobalConstants.AccountsSeeding.AdminEmail,
                        ImageUrl = GlobalConstants.Images.BlogPostFirstImage,
                    },
                    new BlogPost
                    {
                        Title = "Law on condominium ownership",
                        Content = @"IV. CONDOMINIUM

Art. 37. (Amended, SG No. 31/1990) Floors or parts of floors, together with the addition to them of premises in the attic or winter storage, may be joined by separate owners - state, municipal and other legal or natural persons .

Art. 38. Buildings in which floors or parts of stages belong to different owners, common to all owners of land, as a result of which a building of the building, the yard, the foundation, the external walls, the internal partition walls between the separate parts, the internal bearing walls , columns beams, slabs, joists, stairs, platforms, covered, walls between attics and avoid rooms in separate owners, commissions, external entrance doors in the building and doors to municipal attics and avoided rooms, main lines of all types of installations and their central services , associated, gutters, the porter's dwelling and everything else that by its nature or purpose serves for common use. It can be agreed that the parts of the building that serve only some of the separately present floors or parts of floors will be exchanged only for the persons whose premises they serve. The common parts cannot be divided.

Art. 39. The common buildings may be divided with the owners into floors or parts of floors. In the same way, the common building can be divided in court, if the individual floors or parts of the floors can be presented independently without significant alterations and without inconveniences greater than usual.

Art. 40. The shares of individual co-owners in the common parts with proportional to the ratio between the values ​​of the separate premises, which are received, calculations at the establishment of condominium. Subsequent changes in the individual rooms do not affect the size of the partitions. When upgrading a building in condominium ownership, the owners of upgraded floors or parts of floors acquire, against payment, ownership over all common parts of the building, including the land. The shares of all co-owners in the common parts are determined according to the ratio between the values ​​of the individual premises during the completion of the construction. When the owner of a floor or part of a floor transfers a separate part of his property to another person, part of the acquisition and expropriation in common parts of the building is determined by the ratio between the values ​​of the transfer and the part preserved during the transfer. The same rule applies to division.

Art. 41. Each owner, in proportion to his share in the common parts, shall be obliged to participate in expenses, necessary for maintenance or for restoration of them, and in useful variants, for the realization of which a decision has been taken by the general meeting.

Art. 42. Management of the common parts of the building in the main ownership and supervision for fulfillment of the obligations of the occupants as a result of the general meeting of the owners and of the manager or managing board elected by him.

Art. 43. The General Assembly shall take a decision if three quarters of the owners participate in the meeting, personally or through representatives. 2 In the majority of the meeting, voting partners also participate in resolving issues that affect the current property interests or the internal order of the building. In this case, the general meeting will make a decision if more than half of the persons entitled to participate in the meeting are present. If the required number of persons does not appear at the first contraction, the meeting is postponed for one hour later with the same agenda and is considered a law, no matter how many persons appear.

Art. 44. The General Assembly shall take a decision by a majority representing more than half of the owners present. In the case of para. 2 of the previous member of this meeting of the decision with the majority of votes of those present.

Art. 45. The owner of a floor or part of a floor shall be removed from the building by a decision of this meeting: amended, SG No. 33/1996) if he systematically violates the rules or decisions of the general meeting on the internal order in the building or good manners. The general meeting may decide to remove only after the owner has been prepared in advance in writing by the manager, which will be removed from the property and if even after this warning the violation is not terminated.

Art. 46. ​​(amend. SG 59/07, in force from 01.03.2008) The owner may seek from the regional court revocation of the decision for the general meeting for removal by the order, established in the regulations of art. . 49. On the basis of the entered into force decision of this assembly under art. 45 a manager or a chairman of the managing board may request issuance of an order for execution under art. 410, para. 1 of the Code of Civil Procedure.

Art. 47. The manager or the chairman of the management board shall consist of owners in all actions, including litigation, which are related to custom",
                        Author = GlobalConstants.AccountsSeeding.AdminEmail,
                        ImageUrl = GlobalConstants.Images.BlogPostSecondImage,
                    },
                    new BlogPost
                    {
                        Title = "Spatial Planning Act",
                        Content = @"Effective March 31, 2001

Prom. DV. issue 1 of January 2, 2001, amended DV. issue 41 of April 24, 2001, amended DV. No. 111 of December 28, 2001, as amended.

DV. No. 43 of April 26, 2002, as amended. DV. issue 20 of March 4, 2003, amended DV. No. 65 of July 22, 2003, as amended. DV. No. 107

of 9 December 2003, amended DV. No. 36 of April 30, 2004, as amended. DV. No. 65 of July 27, 2004, as amended. DV. issue 28 of 1

April 2005, amended DV. No. 76 of September 20, 2005, as amended. DV. No. 77 of September 27, 2005, as amended. DV. No. 88 of 4

November 2005, amended DV. No. 94 of November 25, 2005, as amended. DV. issue 95 of 29 November 2005, amended DV. issue 103 of

December 23, 2005, as amended. DV. No. 105 of December 29, 2005, as amended. DV. issue 29 of April 7, 2006, amended DV. issue 30 of

April 11, 2006, as amended. DV. issue 34 of 25 April 2006, amended DV. issue 37 of 5 May 2006, amended DV. No. 65 of August 11

2006, amended DV. No. 76 of September 15, 2006, as amended. DV. No. 79 of September 29, 2006, as amended. DV. issue 82 of 10

October 2006

Part One.

BASICS OF THE STRUCTURE OF THE TERRITORY

Chapter One.

GENERAL


Art. 1. (Amended, SG No. 65/2003) (1) The territory of the Republic of Bulgaria shall be a national treasure. Its structure guarantees sustainable development and favorable conditions for living, working and recreation of the population.

(2) This law regulates the public relations, related to the structure of the territory, the investment design and the construction in the Republic of Bulgaria, and determines the restrictions on the property for development purposes.

Art. 2. The Council of Ministers shall determine the main directions and principles of the policy on spatial planning and shall adopt decisions for financing the activities on spatial planning.",
                        Author = GlobalConstants.AccountsSeeding.AdminEmail,
                        ImageUrl = GlobalConstants.Images.BlogPostThirdImage,
                    },
                };

            foreach (var blogPost in blogPosts)
            {
                await dbContext.AddAsync(blogPost);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
