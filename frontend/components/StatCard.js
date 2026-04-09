export default function StatCard({ label, value, trend, tone = 'primary' }) {
  const toneMap = {
    primary: '#6c8cff',
    success: '#34d399',
    warning: '#fbbf24',
    danger: '#f87171'
  };

  return (
    <div className="panel">
      <div className="badge" style={{ background: '#223267' }}>{label}</div>
      <div className="kpi" style={{ color: toneMap[tone] }}>{value}</div>
      <p className="subtitle">{trend}</p>
    </div>
  );
}
