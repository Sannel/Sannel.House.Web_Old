class _Device {
	Id: number;
	Name: string;
	Description: string;
	DisplayOrder: number;
	DateCreated: Date;
	IsReadOnly: boolean;
}

interface Result<T> {
	Success: boolean;
	Errors: String[];
	Data: T;
}

interface PagedResults<T> extends Result<Array<T>> {
	TotalResults: number;
	PageSize: number;
	CurrentPage: number;
}