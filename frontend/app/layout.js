import './globals.css';
import Providers from './providers';

export const metadata = {
  title: 'SaaS HRM Platform',
  description: 'Multi-tenant HRM SaaS foundation'
};

export default function RootLayout({ children }) {
  return (
    <html lang="en">
      <body>
        <Providers>{children}</Providers>
      </body>
      <body>{children}</body>
    </html>
  );
}
