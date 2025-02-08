export interface FilterOptions {
  search?: string;
  searchColumn?: string;
  sortBy?: string;
  order?: 'asc' | 'desc';
  filters?: Record<string, any>;
  limit?: number;
  tags?: string[];
}
