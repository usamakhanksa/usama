export async function apiRequest(path, options = {}) {
  const res = await fetch(`${process.env.NEXT_PUBLIC_API_BASE_URL}${path}`, {
    ...options,
    headers: {
      'Content-Type': 'application/json',
      'X-Tenant-Id': process.env.NEXT_PUBLIC_TENANT_ID || '',
      ...(options.headers || {})
    }
  });

  if (!res.ok) {
    const message = await res.text();
    throw new Error(message || 'Request failed');
  }

  return res.json();
}
