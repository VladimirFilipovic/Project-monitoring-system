using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1
{
    public class TODO
    {
        /*
         * svuda isDeleted...
         * change iheritacce strategy
         */
    }
}

/*/* ako 'obrisemo ili komplitujemo project' svim employeema se smanjuje */
/* email */
/* is active -> end date*/

/* kad dodamo employee-a na project povecava se active projects, takodje ako ga oduzmemo smanjuje se */ /*rollback*/
/*da li ce uspeti ako dva puta insert isto*/
/*CREATE TRIGGER trgEmployeeProject
on EmployeeProject
AFTER INSERT, UPDATE
AS
BEGIN
	declare @EmployeeId int;
if update(EmployeeId)
	BEGIN
		declare ep_cursor cursor for
		select EmployeeId
		from inserted
		open ep_cursor

		fetch next from ep_cursor
			into @EmployeeId
			
		while @@FETCH_STATUS = 0 
			BEGIN
				if @EmployeeId is not null --moze biti null pri insertu pa proveravamo
				BEGIN
					update AspNetUsers
					set NumberOfActiveProjects += 1
				END
				fetch next from ep_cursor
					into @EmployeeId;
END
close ep_cursor
			deallocate ep_cursor
	END
END

insert into EmployeeProject (EmployeeId, ProjectId, RoleOnProject, Deleted) 
values(1, 1, 'Dzabalebaros'); */