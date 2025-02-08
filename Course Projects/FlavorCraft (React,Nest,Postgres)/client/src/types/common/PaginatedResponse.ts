export interface PaginatedResponse<T> {
  totalPages: number;
  currentPage: number;
  totalCount: number;
  pageSize: number;
  data: T[];
}
