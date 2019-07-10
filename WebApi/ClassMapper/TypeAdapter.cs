namespace WebApi.ClassMapper
{
    public class TypeAdapter
    {
        public void Init()
        {
            // 基本
            // TypeAdapterConfig<TSource, TDestination> .NewConfig()
            //.Map(
            // dest => dest.FullName,
            // src => string.Format("{0} {1}", src.FirstName, src.LastName)
            // );
            Mapster.TypeAdapterConfig<WXQ.InOutPutEntites.Input.PageInput, SqlSugar.PageModel>.NewConfig()
                .Map(dest => dest.PageIndex, src => src.PageIndex)
                .Map(dest => dest.PageSize, src => src.PageSize)
                .Map(dest => dest.PageCount, src => 0);
            //  条件
            //        TypeAdapterConfig<TSource, TDestination>
            //.NewConfig()
            //.Map(dest => dest.FullName, src => "Sig. " + src.FullName, srcCond => srcCond.Country == "Italy")
            //.Map(dest => dest.FullName, src => "Sr. " + src.FullName, srcCond => srcCond.Country == "Spain")
            //.Map(dest => dest.FullName, src => "Mr. " + src.FullName);

            //        TypeAdapterConfig<TSource, TDestination>
            //.NewConfig()
            //.Ignore(dest => dest.Id);

            //        TypeAdapterConfig<TSource, TDestination>
            //.NewConfig()
            //.Map(dest => dest.Id, src => src.Id)
            //.Map(dest => dest.Name, src => src.Name)
            //.IgnoreNonMapped(true);

            //        TypeAdapterConfig<TSource, TDestination>
            //.NewConfig()
            //.IgnoreNullValues(true);

            //var dto = TypeAdapter.Adapt<Employee, EmployeeDTO>(employee);
        }
    }
}