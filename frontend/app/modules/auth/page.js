export default function AuthPage() {
  return (
    <main className="container">
      <h1 className="title">Authentication & Authorization</h1>
      <p className="subtitle">JWT + refresh token + role/permission model.</p>
      <section className="panel" style={{ marginTop: 16 }}>
        <ul>
          <li>Register</li>
          <li>Login</li>
          <li>Refresh token</li>
          <li>Password reset + email verification</li>
        </ul>
      </section>
    </main>
  );
  return <div style={{ padding: 24 }}>Auth module shell (JWT + refresh token flow).</div>;
}
