export default function LeavePage() {
  return (
    <main className="container">
      <h1 className="title">Leave Management</h1>
      <p className="subtitle">Apply, approve, and track balances per tenant policy.</p>
      <section className="panel" style={{ marginTop: 16 }}>
        <ul>
          <li>✅ Annual / Sick / Maternity / Emergency leave types</li>
          <li>✅ Approval workflow integration</li>
          <li>✅ Leave balance recalculation queue support</li>
        </ul>
      </section>
    </main>
  );
  return <div style={{ padding: 24 }}>Leave module shell.</div>;
}
