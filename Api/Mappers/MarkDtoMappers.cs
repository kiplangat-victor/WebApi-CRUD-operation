using Api.Dtos.Marks;
using Api.Models;

namespace Api;

public static class MarkDtoMappers
{
    public static MarksDto MarksToDto(this Marks  marks )
    {
        return new MarksDto{
            Maths=marks.Maths,
            English=marks.English,
            Kiswahili=marks.Kiswahili,
            Chemistry=marks.Chemistry,
            StudentId=marks.StudentId,

        };
    }
    public static Marks DtoToMarks(this CreateDto marksDto,int id)
    {
        return new Marks{
            Maths=marksDto.Maths,
            English=marksDto.English,
            Kiswahili=marksDto.Kiswahili,
            Chemistry=marksDto.Chemistry,
            StudentId=id

        };
    }
    public static Marks UpdateDtoToMarks(this UpdateDto update)
    {
        return new Marks{
            Maths=update.Maths,
            English=update.English,
            Kiswahili=update.Kiswahili,
            Chemistry=update.Chemistry,
            // StudentId=id
        };
    }

}
