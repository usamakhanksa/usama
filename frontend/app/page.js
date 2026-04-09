import Link from 'next/link';

export default function HomePage() {
  return (
    <main style={{ padding: 24, fontFamily: 'sans-serif' }}>
      <h1>SaaS HRM Platform Foundation</h1>
      <p>Clean Architecture, Multi-Tenancy, HRM Modules, and Billing-ready scaffolding.</p>
      <ul>
        <li><Link href="/modules/employees">Employees</Link></li>
        <li><Link href="/modules/leave">Leave</Link></li>
        <li><Link href="/modules/payroll">Payroll</Link></li>
        <li><Link href="/modules/auth">Auth</Link></li>
      </ul>
    </main>
  );
}
