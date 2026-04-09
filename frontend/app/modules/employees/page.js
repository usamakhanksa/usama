'use client';

import { useEmployees } from '../../../hooks/useEmployees';

export default function EmployeesPage() {
  const { data, isLoading, error } = useEmployees();

  return (
    <main className="container">
      <h1 className="title">Employee Directory</h1>
      <p className="subtitle">Cached with React Query (stale time: 2 minutes).</p>

      <section className="panel" style={{ marginTop: 16 }}>
        {isLoading && <p>Loading employees…</p>}
        {error && <p style={{ color: '#f87171' }}>Could not load employees from API.</p>}
        {!isLoading && !error && (
          <table className="table">
            <thead>
              <tr>
                <th>Employee #</th>
                <th>Name</th>
                <th>Email</th>
                <th>Status</th>
              </tr>
            </thead>
            <tbody>
              {(data || []).slice(0, 10).map((emp) => (
                <tr key={emp.id}>
                  <td>{emp.employeeNumber}</td>
                  <td>{emp.firstName} {emp.lastName}</td>
                  <td>{emp.email}</td>
                  <td>{emp.status}</td>
                </tr>
              ))}
              {(!data || data.length === 0) && (
                <tr>
                  <td colSpan={4}>No employees returned yet.</td>
                </tr>
              )}
            </tbody>
          </table>
        )}
      </section>
    </main>
  );
}
