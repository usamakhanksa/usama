'use client';

import { useQuery } from '@tanstack/react-query';
import { apiRequest } from '../lib/api';

export function useEmployees() {
  return useQuery({
    queryKey: ['employees', 'list'],
    queryFn: () => apiRequest('/api/v1/employees'),
    staleTime: 2 * 60_000,
    gcTime: 30 * 60_000
  });
}
