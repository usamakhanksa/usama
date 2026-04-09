export const metadata = {
  title: 'SaaS HRM Platform',
  description: 'Multi-tenant HRM SaaS foundation'
};

export default function RootLayout({ children }) {
  return (
    <html lang="en">
      <body>{children}</body>
    </html>
  );
}
