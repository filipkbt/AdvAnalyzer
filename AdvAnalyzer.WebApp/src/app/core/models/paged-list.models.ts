export interface PagedList {
    count: number;
    data: any[];
    hasNextPage: boolean;
    hasPreviousPage: boolean;
}