import Link from 'next/link';
import StatCard from '../components/StatCard';

const modules = [
  { href: '/modules/employees', title: 'Employees', desc: 'Profiles, contracts, docs, and org assignments.' },
  { href: '/modules/leave', title: 'Leave', desc: 'Leave balances, approvals, holiday calendars.' },
  { href: '/modules/payroll', title: 'Payroll', desc: 'Runs, payslips, components, and currencies.' },
  { href: '/modules/auth', title: 'Auth', desc: 'Registration, login, refresh, and security flows.' }
];

export default function HomePage() {
  return (
    <main className="container">
      <h1 className="title">SaaS HRM Control Center</h1>
      <p className="subtitle">Clean Architecture · Multi-Tenant · Cached UI · Queue-Ready Workflows</p>

      <section className="grid cols-4" style={{ marginTop: 20 }}>
        <StatCard label="Headcount" value="1,284" trend="+4.2% vs last month" tone="success" />
        <StatCard label="Pending Leaves" value="38" trend="Requires manager approval" tone="warning" />
        <StatCard label="Payroll Ready" value="96.1%" trend="Current period validation" tone="primary" />
        <StatCard label="Failed Jobs" value="2" trend="Needs retry in queue" tone="danger" />
      </section>

      <section className="grid cols-3" style={{ marginTop: 20 }}>
        {modules.map((m) => (
          <article className="panel" key={m.href}>
            <h3 style={{ marginTop: 0 }}>{m.title}</h3>
            <p className="subtitle">{m.desc}</p>
            <div style={{ marginTop: 12 }}>
              <Link href={m.href}>Open module →</Link>
            </div>
          </article>
        ))}
      </section>

      <nav className="nav">
        <Link href="/modules/employees">Employees</Link>
        <Link href="/modules/leave">Leave</Link>
        <Link href="/modules/payroll">Payroll</Link>
        <Link href="/modules/auth">Auth</Link>
      </nav>
    </main>
  );
}
